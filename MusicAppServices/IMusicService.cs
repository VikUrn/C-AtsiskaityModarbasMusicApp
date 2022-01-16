using MusicAppModels;
using System.Threading.Tasks;

namespace MusicAppServices
{
    public interface IMusicService
    {
        Task<Music> AddSong(Music music);
        Music SongById(int? id);
        Task<Music> SongByIdAsync(int? id);
        Task <Music> EdistSong (Music music);
        Task<Music> RemoveSong (Music music);
    }
}
