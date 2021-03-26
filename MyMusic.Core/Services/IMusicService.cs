using MyMusic.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMusic.Core.Services
{
    public interface IMusicService
    {
        Task<IEnumerable<Music>> GetAllMusicsAsync();
        Task<Music> CreateMusicAsync(Music music);
        Task UpdateMusicAsync(Music musicToBeUpdated , Music music);
        void DeleteMusic(Music music);
        Task<Music> GetMusicById(int id);
        Task<Music> GetMusicByArtistIdAsync(int artistId);
    }
}
