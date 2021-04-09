using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetProject.Domain;
using DotNetProject.Domain.Contracts;
using DotNetProject.Domain.Models;

namespace DotNetProject.DataAccess.Contracts
{
    public interface IAlbumDataAccess
    {
        Task<Album> InsertAsync(AlbumUpdateModel album);
        Task<IEnumerable<Album>> GetAsync();
        Task<Album> GetAsync(IAlbumIdentity albumId);
        Task<Album> UpdateAsync(AlbumUpdateModel album);
    }
}
