using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetProject.DataAccess.Contracts;
using DotNetProject.BLL.Contracts;
using DotNetProject.Domain;
using DotNetProject.Domain.Contracts;

namespace DotNetProject.BLL.Implementation
{
    public class AlbumGetService
    {
        private IAlbumDataAccess AlbumDataAccess { get; }

        public AlbumGetService(IAlbumDataAccess albumDataAccess)
        {
            this.AlbumDataAccess = albumDataAccess;
        }

        public Task<IEnumerable<Album>> GetAsync()
        {
            return this.AlbumDataAccess.GetAsync();
        }

        public Task<Album> GetAsync(IAlbumIdentity album)
        {
            return this.AlbumDataAccess.GetAsync(album);
        }
    }
}
