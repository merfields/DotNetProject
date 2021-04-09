using System;
using System.Threading.Tasks;
using DotNetProject.DataAccess.Contracts;
using DotNetProject.BLL.Contracts;
using DotNetProject.Domain;
using DotNetProject.Domain.Contracts;

namespace DotNetProject.BLL.Implementation
{
    public class ArtistGetService
    {
        private IArtistDataAccess ArtistDataAccess { get; }

        public ArtistGetService(IArtistDataAccess artistDataAccess)
        {
            this.ArtistDataAccess = artistDataAccess;
        }

        public async Task ValidateAsync(IArtistContainer artistContainer)
        {
            if (artistContainer == null)
            {
                throw new ArgumentNullException(nameof(artistContainer));
            }

            var artist = await this.GetBy(artistContainer);

            if (artistContainer.ArtistId.HasValue && artist == null)
            {
                throw new InvalidOperationException($"Artist not found by id {artistContainer.ArtistId}");
            }
        }

        private async Task<Artist> GetBy(IArtistContainer artistContainer)
        {
            return await this.ArtistDataAccess.GetByAsync(artistContainer);
        }
    }
}
