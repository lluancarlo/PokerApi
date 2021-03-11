using PokerApi.Model.Dto.Place;
using PokerApi.Model.Entities;

namespace PokerApi.Business.Interfaces.Mappers
{
    public interface IPlaceMapper
    {
        PlaceEntity MapperToEntity(PlacePostDto dto);
        PlaceEntity MapperToEntity(PlacePutDto dto);
    }
}
