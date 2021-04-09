using System.Threading.Tasks;
using AutoMapper;
using DotNetProject.DataAccess.Context;
using DotNetProject.DataAccess.Contracts;
using DotNetProject.Domain;
using DotNetProject.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DotNetProject.DataAccess.Implementations
{
    class ArtistDataAccess
    {
        private AlbumDirectoryContext Context { get; }
        private IMapper Mapper { get; }

        public ArtistDataAccess(AlbumDirectoryContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<Artist> GetByAsync(IArtistContainer album)
        {
            return album.ArtistId.HasValue
                ? this.Mapper.Map<Artist>(await this.Context.Artist.FirstOrDefaultAsync(x => x.Id == album.ArtistId))
                : null;
        }
    }
}
