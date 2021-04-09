using System.Threading.Tasks;
using DotNetProject.Domain;
using DotNetProject.Domain.Contracts;

namespace DotNetProject.BLL.Contracts
{
    public interface IArtistGetService
    {
        Task ValidateAsync(IArtistContainer artistContainer);
    }
}
