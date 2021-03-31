using MyMusic.Core;
using MyMusic.Core.Models;
using MyMusic.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Services.Services
{
    public class MusicService : IMusicService
    {
        private readonly IUnitOfWork _unitOfWork; // Inject UnitOfWork

        public MusicService(IUnitOfWork unitOfWork) // UnitOfWork
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Music> CreateMusicAsync(Music music)
        {
            var result = await _unitOfWork.Musics.AddAsync(music);
            await _unitOfWork.CommitAsync();
            return result;
        }

        public async void DeleteMusic(Music music)
        {
            _unitOfWork.Musics.Remove(music);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Music>> GetAllMusicsAsync()
        {
            return await this._unitOfWork.Musics.GetAllAsync();
        }

        public async Task<IEnumerable<Music>> GetAllMusicsWithArtistAsync()
        {
            return await this._unitOfWork.Musics.GetAllWthArtisAsync();
        }

        public async Task<Music> GetMusicByArtistIdAsync(int artistId)
        {
            return await this._unitOfWork.Musics.GetMusicByArtistIdAsync(artistId);
        }

        public async Task<Music> GetMusicById(int id)
        {
            return await _unitOfWork.Musics.GetByIdAsync(id);
        }

        public async Task UpdateMusicAsync(Music musicToBeUpdated, Music music)
        {
            musicToBeUpdated.Name = music.Name;
            musicToBeUpdated.ArtistId = music.ArtistId;
            await _unitOfWork.CommitAsync();
        }
    }
}
