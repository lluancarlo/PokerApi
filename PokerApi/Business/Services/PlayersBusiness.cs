using Microsoft.EntityFrameworkCore;
using PokerApi.Business.Interfaces.Mappers;
using PokerApi.Business.Interfaces.Service;
using PokerApi.Domain.Interfaces;
using PokerApi.Model.Dto.Player;
using PokerApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokerApi.Business.Services
{
    public class PlayersBusiness : IPlayersBusiness
    {
        private readonly IPlayerRepository _repository;
        private readonly IPlayerMapper _mapper;

        public PlayersBusiness(IPlayerRepository repository, IPlayerMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlayerEntity>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PlayerEntity> GetById(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }

        public async Task<PlayerEntity> Post(PlayerPostDto player)
        {
            PlayerEntity playerEntity = _mapper.MapperToEntity(player);
            playerEntity.Created_At = DateTime.Now;

            await _repository.PostAsync(playerEntity);
            await _repository.CommitAsync();

            return playerEntity;
        }

        public async Task Put(int Id, PlayerPutDto player)
        {
            PlayerEntity playerEntity = _mapper.MapperToEntity(player);

            var result = await _repository.GetByIdAsync(Id);
            result.Name = playerEntity.Name;
            result.Email = playerEntity.Email;
            result.User = playerEntity.User;
            result.Password = playerEntity.Password;
            result.Updated_At = DateTime.Now;

            await _repository.PutAsync(result);
            await _repository.CommitAsync();
        }

        public async Task Delete(int Id)
        {
            await _repository.DeleteAsync(Id);
            await _repository.CommitAsync();
        }
    }
}
