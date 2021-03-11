using PokerApi.Model.Dto.Player;
using PokerApi.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokerApi.Business.Interfaces.Service
{
    public interface IPlayersBusiness
    {
        public Task<IEnumerable<PlayerEntity>> GetAll();
        public Task<PlayerEntity> GetById(int Id);
        public Task<PlayerEntity> Post(PlayerPostDto player);
        public Task Put(int Id, PlayerPutDto player);
        public Task Delete(int Id);
    }
}
