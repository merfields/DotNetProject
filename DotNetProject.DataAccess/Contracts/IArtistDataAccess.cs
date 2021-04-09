using System.Threading.Tasks;
using DotNetProject.Domain;
using DotNetProject.Domain.Contracts;


namespace DotNetProject.DataAccess.Contracts
{
    public interface IArtistDataAccess
    {
        Task<Artist> GetByAsync(IArtistContainer artistId);
    }
}
