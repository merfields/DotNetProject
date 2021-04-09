using System.Threading.Tasks;
using DotNetProject.Domain;
using DotNetProject.Domain.Models;

namespace DotNetProject.BLL.Contracts
{
    public interface IAlbumUpdateService
    {
        Task<Album> UpdateAsync(AlbumUpdateModel album);
    }
}
