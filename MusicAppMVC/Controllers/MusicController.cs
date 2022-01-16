using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicAppDbContext;
using MusicAppModels;
using MusicAppServices;
using System.Threading.Tasks;

namespace MusicAppMVC.Controllers
{
    public class MusicController : Controller
    {
        private readonly MusicAppContext _context;
        private readonly ILogger<MusicController> _logger;
        private readonly IMusicService _service;

        public MusicController(MusicAppContext context, ILogger<MusicController> logger, IMusicService service)
        {
            _context = context;
            _logger = logger;
            _service = service;
        }

        // Dainų sąrašo pradinis puslapis
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("opened song list");

            return View(await _context.Musics.ToListAsync()); // visą sarašą paima
        }

        [Authorize]
        // Dainos informacijos peržiūrėjimas
        public IActionResult Details(int? id)
        {
            _logger.LogInformation("song details");

            var music = _service.SongById(id);
            return View(music);
        }

        // atidaromas puslapis naujai dainai sukurti
        [Authorize]
        public IActionResult Create()
        {
            _logger.LogInformation("opened creat window");
            return View();
        }

        // naujos dainos sukurimas
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Music music)
        {
            _logger.LogInformation("created new song");

            if (ModelState.IsValid) // patikrinama ar atitinka parametrus
            {
                await _service.AddSong(music);
                //await _context.AddAsync(music); // prideda naujos dainos informacja duonbazėje
                //await _context.SaveChangesAsync(); // išsaugo pakeitimus
                return RedirectToAction("Index", "Music");
            }
            return View(music);
        }

        // atidaromas langas dainos informacijos keitimui
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            _logger.LogInformation("opened edit window");

            var music = await _service.SongByIdAsync(id); // surandama daina            
            return View(music);
        }

        // pakeistos informacijos išsaugojimas
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MusicId,Performer,Title,Genre,Url")] Music music)
        {
            _logger.LogInformation("song was edited");

            if (id != music.MusicId) // patikrina ar toks id yra 
            {
                return NotFound();
            }

            if (ModelState.IsValid) // patikrinama ar įvesta informacija atitinka parametrus
            {
                await _service.EdistSong(music); // atnaujina informaciją apie dainą
                return RedirectToAction("Index", "Music"); // gražina į nurodytą puslapį
            }
            return View(music);
        }

        // atidaromas puslapis dainos ištrynimui
        [Authorize]
        public IActionResult Delete(int? id)
        {
            _logger.LogInformation("opened delete window");

            var music = _service.SongById(id); // surandama daina pagal id
            return View(music);
        }

        // ištrinimas dainos
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            _logger.LogInformation("song was deleted");

            var music = await _service.SongByIdAsync(id); // surnada dainą
            await _service.RemoveSong(music); // pašalina dainą ir išsaugo informaciją duonbazėje
            return RedirectToAction("Index", "Music");
        }
    }
}
