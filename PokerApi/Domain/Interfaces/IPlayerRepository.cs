using PokerApi.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokerApi.Domain.Interfaces
{
    public interface IPlayerRepository : IGenericRepository
    {
        Task<IEnumerable<PlayerEntity>> GetAllAsync();
        Task<PlayerEntity> GetByIdAsync(int playerId);
        Task PostAsync(PlayerEntity player);
        Task PutAsync(PlayerEntity player);
        Task DeleteAsync(int playerId);
    }
}
