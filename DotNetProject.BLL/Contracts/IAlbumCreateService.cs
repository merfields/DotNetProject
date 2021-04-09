using System.Threading.Tasks;
using DotNetProject.Domain;
using DotNetProject.Domain.Models;

namespace DotNetProject.BLL.Contracts
{
    public interface IAlbumCreateService
    {
        Task<Album> CreateAsync(AlbumUpdateModel album);
    }
}
