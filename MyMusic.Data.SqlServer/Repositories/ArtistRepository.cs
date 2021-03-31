using Microsoft.EntityFrameworkCore;
using MyMusic.Core.Models;
using MyMusic.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMusic.Data.SqlServer.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        private MyMusicDbContext myContext
        {
            get { return Context as MyMusicDbContext; }
        }
        public ArtistRepository(MyMusicDbContext context): base(context)
        {

        }
        public async Task<IEnumerable<Artist>> GetAllWithMusicAsync()
        {
            return await this.myContext.Artists.Include(o => o.Musics).ToListAsync();
        }

        public async Task<Artist> GetArtistByIdWithMusicAsync(int id)
        {
            return await this.myContext.Artists.Include(o => o.Musics).
                SingleOrDefaultAsync(o => o.Id == id);
        }
    }
}