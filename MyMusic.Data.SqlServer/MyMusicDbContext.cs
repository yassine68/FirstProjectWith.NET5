using Microsoft.EntityFrameworkCore;
using MyMusic.Core.Models;
using MyMusic.Data.SqlServer.Configuration;

namespace MyMusic.Data.SqlServer
{
    public class MyMusicDbContext : DbContext
    {
        // Tables
        public DbSet<Music> Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }

        // Inject Constructor
        public MyMusicDbContext(DbContextOptions<MyMusicDbContext> options) : base(options)
        {

        }

        // Appl the Configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MusicConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
        }
    }
}
