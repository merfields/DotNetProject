using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotNetProject.DataAccess.Context;
using DotNetProject.DataAccess.Contracts;
using DotNetProject.DataAccess.Entities;
using DotNetProject.Domain.Contracts;
using DotNetProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Artist = DotNetProject.Domain.Artist;

namespace DotNetProject.DataAccess.Implementations
{
    class AlbumDataAccess
    {
        private AlbumDirectoryContext Context { get; }
        private IMapper Mapper { get; }

        public AlbumDataAccess(AlbumDirectoryContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<Domain.Album> InsertAsync(AlbumUpdateModel album)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Album>(album));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Domain.Album>(result.Entity);
        }

        public async Task<IEnumerable<Domain.Album>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Domain.Album>>(
                await this.Context.Album.Include(x => x.Artist).ToListAsync());
        }

        public async Task<Domain.Album> GetAsync(IAlbumIdentity album)
        {
            var result = await this.Get(album);

            return this.Mapper.Map<Domain.Album>(result);
        }

        private async Task<Album> Get(IAlbumIdentity album)
        {
            if (album == null)
            {
                throw new ArgumentNullException(nameof(album));
            }

            return await this.Context.Album.Include(x => x.Artist)
                .FirstOrDefaultAsync(x => x.Id == album.Id);
        }

        public async Task<Domain.Album> UpdateAsync(AlbumUpdateModel album)
        {
            var existing = await this.Get(album);

            var result = this.Mapper.Map(album, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Domain.Album>(result);
        }
    }
}
