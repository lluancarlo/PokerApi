using PokerApi.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokerApi.Domain.Interfaces
{
    public interface IFinancialRepository : IGenericRepository
    {
        Task<IEnumerable<FinancialEntity>> GetAllAsync();
        Task<FinancialEntity> GetByIdAsync(int playerId, int placeId);
        Task PostAsync(FinancialEntity financial);
        Task PutAsync(FinancialEntity financial);
        Task DeleteAsync(int playerId, int placeId);
    }
}
