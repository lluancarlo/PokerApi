using System.Threading.Tasks;

namespace PokerApi.Domain.Interfaces
{
    public interface IGenericRepository
    {
        Task CommitAsync();
    }
}
