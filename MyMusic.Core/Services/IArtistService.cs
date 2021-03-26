using MyMusic.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyArtist.Core.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<Artist>> GetAllArtistAsync();
        Task<Artist> CreateArtistAsync(Artist Artist);
        Task UpdateArtistAsync(Artist ArtistToBeUpdated , Artist Artist);
        void DeleteArtist(Artist Artist);
        Task<Artist> GetArtistById(int id);
    }
}
