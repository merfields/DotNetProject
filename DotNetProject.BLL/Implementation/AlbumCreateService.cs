using System;
using System.Threading.Tasks;
using DotNetProject.DataAccess.Contracts;
using DotNetProject.BLL.Contracts;
using DotNetProject.Domain;
using DotNetProject.Domain.Models;

namespace DotNetProject.BLL.Implementation
{
    public class AlbumCreateService
    {
        private IAlbumDataAccess AlbumDataAccess { get; }
        private IArtistGetService ArtistGetService { get; }

        public AlbumCreateService(IAlbumDataAccess albumDataAccess, IArtistGetService artistGetService)
        {
            this.AlbumDataAccess = albumDataAccess;
            this.ArtistGetService = artistGetService;
        }

        public async Task<Album> CreateAsync(AlbumUpdateModel album)
        {
            await this.ArtistGetService.ValidateAsync(album);

            return await this.AlbumDataAccess.InsertAsync(album);
        }
    }
}
