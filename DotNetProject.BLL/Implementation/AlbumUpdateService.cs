using System;
using System.Threading.Tasks;
using DotNetProject.DataAccess.Contracts;
using DotNetProject.BLL.Contracts;
using DotNetProject.Domain;
using DotNetProject.Domain.Contracts;
using DotNetProject.Domain.Models;


namespace DotNetProject.BLL.Implementation
{
    public class AlbumUpdateService
    {
        private IAlbumDataAccess AlbumDataAccess { get; }
        private IArtistGetService ArtistGetService { get; }

        public AlbumUpdateService(IAlbumDataAccess albumDataAccess, IArtistGetService artistGetService)
        {
            this.AlbumDataAccess = albumDataAccess;
            this.ArtistGetService = artistGetService;
        }

        public async Task<Album> UpdateAsync(AlbumUpdateModel album)
        {
            await this.ArtistGetService.ValidateAsync(album);

            return await this.AlbumDataAccess.UpdateAsync(album);
        }
    }
}
