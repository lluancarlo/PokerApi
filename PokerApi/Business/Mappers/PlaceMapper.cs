using PokerApi.Business.Interfaces.Mappers;
using PokerApi.Model.Dto.Place;
using PokerApi.Model.Entities;

namespace PokerApi.Business.Mappers
{
    public class PlaceMapper : IPlaceMapper
    {
        public PlaceEntity MapperToEntity(PlacePostDto dto)
        {
            return new PlaceEntity
            {
                Id = 0,
                Name = dto.Name,
                Created_At = null,
                Updated_At = null
            };
        }

        public PlaceEntity MapperToEntity(PlacePutDto dto)
        {
            return new PlaceEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                Created_At = null,
                Updated_At = null
            };
        }
    }
}
