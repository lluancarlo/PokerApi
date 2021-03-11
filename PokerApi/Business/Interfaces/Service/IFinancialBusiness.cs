using PokerApi.Model.Dto.Financial;
using PokerApi.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokerApi.Business.Interfaces.Service
{
    public interface IFinancialBusiness
    {
        public Task<IEnumerable<FinancialEntity>> GetAll();
        public Task<FinancialEntity> GetById(int playerId, int placeId);
        public Task<FinancialEntity> Post(FinancialPostDto player);
        public Task Put(int playerId, int placeId, FinancialPutDto player);
        public Task Delete(int playerId, int placeId);
    }
}
