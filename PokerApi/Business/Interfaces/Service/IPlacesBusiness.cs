using PokerApi.Model.Dto.Place;
using PokerApi.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokerApi.Business.Interfaces.Service
{
    public interface IPlacesBusiness
    {
        public Task<IEnumerable<PlaceEntity>> GetAll();
        public Task<PlaceEntity> GetById(int Id);
        public Task<PlaceEntity> Post(PlacePostDto player);
        public Task Put(int Id, PlacePutDto player);
        public Task Delete(int Id);
    }
}
