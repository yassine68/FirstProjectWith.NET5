using MyMusic.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace MyMusic.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IArtistRepository Artists { get; }
        IMusicRepository Musics { get; }
        Task<int> CommitAsync();
    }
}
