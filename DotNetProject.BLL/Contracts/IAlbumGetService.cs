using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetProject.Domain;
using DotNetProject.Domain.Contracts;

namespace DotNetProject.BLL.Contracts
{
    public interface IAlbumGetService
    {
        Task<IEnumerable<Album>> GetAsync();
        Task<Album> GetAsync(IAlbumIdentity album);
    }
}
