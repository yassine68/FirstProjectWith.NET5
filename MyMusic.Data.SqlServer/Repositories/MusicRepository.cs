using Microsoft.EntityFrameworkCore;
using MyMusic.Core.Models;
using MyMusic.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Data.SqlServer.Repositories
{
    public class MusicRepository : Repository<Music>, IMusicRepository
    {
        private MyMusicDbContext myMusicDbContext
        {
            get { return Context as MyMusicDbContext; }
        }
        public MusicRepository(MyMusicDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Music>> GetAllWithArtistByArtistIdAsync(int artistId)
        {
            return await this.myMusicDbContext.Musics.
                Include(o => o.Artist).
                Where(o => o.ArtistId == artistId).ToListAsync();
        }

        public async Task<IEnumerable<Music>> GetAllWthArtisAsync()
        {
            return await this.myMusicDbContext.Musics.
                Include(o => o.Artist).ToListAsync();
        }

        public async Task<Music> GetWithArtistByIdAsync(int id)
        {
            return await this.myMusicDbContext.Musics.
                Include(o => o.Artist).
                SingleOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Music> GetMusicByArtistIdAsync(int artistId)
        {
            return await myMusicDbContext.Musics.SingleOrDefaultAsync(o => o.ArtistId == artistId);
        }
    }
}