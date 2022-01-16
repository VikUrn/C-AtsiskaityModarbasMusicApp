using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicAppModels;
using MusicAppMVC.ViewModels;
using System.Threading.Tasks;

namespace MusicAppMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userServise;
        private readonly SignInManager<User> _signInService;
        private readonly ILogger<AuthController> _logger;
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AuthController> logger)
        {
            _userServise = userManager;
            _signInService = signInManager;
            _logger = logger;
        }

        //public IActionResult Index() => RedirectToAction("Registration");

        // vartotojo registracija
        public IActionResult Registration()
        {
            _logger.LogInformation("opened registration page");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            _logger.LogInformation("new user was registered");

            //patikirna ar įvesti duomenys atitinka reikalavimus ir ar teisingas įvestas slaptažodus abu kartus
            if (ModelState.IsValid && (model.Password == model.ConfirmPassword)) 
            {
                // sukuriamas naujas vartotojas
                var newUser = new User() { Email = model.Email, UserName = model.Email, FullName = model.Name };

                // išsaugomi duomenys
                var result = await _userServise.CreateAsync(newUser, model.Password);

                if (result.Succeeded) // nukreipiama į login puslapį jei registracija sėkminga
                {
                    return RedirectToAction("Login", "Auth");
                }
            }
            return View(model);
        }

        // prisijungimas vartotojo
        public IActionResult Login()
        {
            _logger.LogInformation("opened login page");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            _logger.LogInformation("user logged");

            if (ModelState.IsValid) // patikrinama ar atitinka nustatytus parametrus
            {
                var myUser = await _userServise.FindByEmailAsync(model.Email); // surandamas vartotojas pagal įvestą emailą

                if (myUser != null) 
                {
                    var result = await _signInService.PasswordSignInAsync(myUser, model.Password, false, false); // patikrinamas ar geras slaptaždis įvestas

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Music"); 
                    }
                    else
                    {
                        return RedirectToAction("ErrorLogin", "Home");
                    }

                }
            }
            return View(model);
        }

        // vartotojo atsijungimas
        public async Task<IActionResult> LogOut()
        {
            _logger.LogInformation("user logged out");

            await _signInService.SignOutAsync(); // vartotojo atjungimas
            return RedirectToAction("Login", "Auth");
        }

    }
}
