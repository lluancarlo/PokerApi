using PokerApi.Model.Dto.Financial;
using PokerApi.Model.Entities;

namespace PokerApi.Business.Interfaces.Mappers
{
    public interface IFinancialMapper
    {
        FinancialEntity MapperToEntity(FinancialPostDto dto);
        FinancialEntity MapperToEntity(FinancialPutDto dto);
    }
}
