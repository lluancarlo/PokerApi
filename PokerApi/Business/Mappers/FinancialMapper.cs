using PokerApi.Business.Interfaces.Mappers;
using PokerApi.Model.Dto.Financial;
using PokerApi.Model.Entities;

namespace PokerApi.Business.Mappers
{
    public class FinancialMapper : IFinancialMapper
    {
        public FinancialEntity MapperToEntity(FinancialPostDto dto)
        {
            return new FinancialEntity
            {
                PlayerId = dto.PlayerId,
                PlaceId = dto.PlaceId,
                Balance = dto.Balance,
                Created_At = null,
                Updated_At = null
            };
        }

        public FinancialEntity MapperToEntity(FinancialPutDto dto)
        {
            return new FinancialEntity
            {
                PlayerId = dto.PlayerId,
                PlaceId = dto.PlaceId,
                Balance = dto.Balance,
                Created_At = null,
                Updated_At = null
            };
        }
    }
}
