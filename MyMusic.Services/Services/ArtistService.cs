using MyArtist.Core.Services;
using MyMusic.Core;
using MyMusic.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMusic.Services.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArtistService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Artist> CreateArtistAsync(Artist Artist)
        {
            var result = await _unitOfWork.Artists.AddAsync(Artist);
            await _unitOfWork.CommitAsync();
            return result;
        }

        public async void DeleteArtist(Artist Artist)
        {
            _unitOfWork.Artists.Remove(Artist);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Artist>> GetAllArtistAsync()
        {
            return await _unitOfWork.Artists.GetAllAsync();
        }

        public async Task<Artist> GetArtistById(int id)
        {
            return await _unitOfWork.Artists.GetByIdAsync(id);
        }

        public async Task UpdateArtistAsync(Artist ArtistToBeUpdated, Artist Artist)
        {
            ArtistToBeUpdated.Name = Artist.Name;
            await _unitOfWork.CommitAsync();
        }
    }
}