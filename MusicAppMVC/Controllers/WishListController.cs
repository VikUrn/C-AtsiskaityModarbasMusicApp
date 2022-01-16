using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicAppDbContext;
using MusicAppModels;
using MusicAppServices;
using System.Threading.Tasks;

namespace MusicAppMVC.Controllers
{
    public class WishListController : Controller
    {
        private readonly MusicAppContext _context;
        private readonly ILogger<WishListController> _logger;
        private readonly IMusicService _service;

        public WishListController(MusicAppContext context, ILogger<WishListController> logger, IMusicService service)
        {
            _context = context;
            _logger = logger;
            _service = service;
        }
        // ideda dainą prie mėgstamiausių
        [Authorize]
        public async Task<IActionResult> AddToWishList(int id, [Bind("WishListId, Users.Id, Musics.MusicId")] WishList wishlist)
        {

            _logger.LogInformation("added song to wishlist");

            //var song = _service.SongById(id);
            //var user = await _context.Users.FindAsync(id);

            //var nWish = new WishList();
            //nWish.MusicId = song;
            //nWish.Id = await _context.Users.FindAsync(id);

            await _context.AddAsync(wishlist);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Music");
        }
    }
}
