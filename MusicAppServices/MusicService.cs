using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicAppDbContext;
using MusicAppModels;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAppServices
{
    public class MusicService : IMusicService
    {
        private readonly MusicAppContext _context;
        private readonly ILogger<MusicService> _logger;

        public MusicService(MusicAppContext context, ILogger<MusicService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Music> AddSong(Music music)
        {
            _logger.LogInformation("AddSong");

            using (var context = new MusicAppContext())
            {
                await context.Musics.AddAsync(music);
                await context.SaveChangesAsync();
            }
            return music;
        }

        public Music SongById(int? id)
        {
            _logger.LogInformation("SongById");

            return _context.Musics.FirstOrDefault(m => m.MusicId == id);
        }

        public async Task<Music> SongByIdAsync(int? id)
        {
            _logger.LogInformation("SongByIdAsync");

            return await _context.Musics.FirstAsync(t => t.MusicId == id);
        }

        public async Task<Music> EdistSong(Music music)
        {
            _logger.LogInformation("EditSong");

            using (var context = new MusicAppContext())
            {
                context.Update(music); // ataujinama informacija
                await context.SaveChangesAsync(); // išsaugo pakeitimus
            }
            return music;
        }

        public async Task<Music> RemoveSong(Music music)
        {
            _logger.LogInformation("RemoveSong");

            using (var context = new MusicAppContext())
            {
                _context.Musics.Remove(music); // pašalina iš duomenų bazęs
                await _context.SaveChangesAsync(); // išsaugo pakeitimus
            }
            return music;
        }

    }
}
