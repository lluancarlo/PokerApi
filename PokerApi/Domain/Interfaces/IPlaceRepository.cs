using PokerApi.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokerApi.Domain.Interfaces
{
    public interface IPlaceRepository : IGenericRepository
    {
        Task<IEnumerable<PlaceEntity>> GetAllAsync();
        Task<PlaceEntity> GetByIdAsync(int placeId);
        Task PostAsync(PlaceEntity place);
        Task PutAsync(PlaceEntity place);
        Task DeleteAsync(int placeId);
    }
}
