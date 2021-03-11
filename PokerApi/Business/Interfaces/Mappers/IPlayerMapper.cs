using PokerApi.Model.Dto.Player;
using PokerApi.Model.Entities;

namespace PokerApi.Business.Interfaces.Mappers
{
    public interface IPlayerMapper
    {
        PlayerEntity MapperToEntity(PlayerPostDto dto);
        PlayerEntity MapperToEntity(PlayerPutDto dto);
    }
}
