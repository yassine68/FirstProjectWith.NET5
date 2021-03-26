using MyMusic.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMusic.Core.Repositories
{
    public interface IMusicRepository : IRepository<Music>
    {
        Task<IEnumerable<Music>> GetAllWthArtisAsync();
        Task<Music> GetWithArtistByIdAsync(int id);
        Task<IEnumerable< Music>>  GetAllWithArtistByArtistIdAsync(int artistId);
    }
}
