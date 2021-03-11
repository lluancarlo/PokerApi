using PokerApi.Business.Interfaces.Mappers;
using PokerApi.Model.Dto.Player;
using PokerApi.Model.Entities;
using System;

namespace PokerApi.Business.Mappers
{
    public class PlayerMapper : IPlayerMapper
    {
        public PlayerEntity MapperToEntity(PlayerPostDto dto)
        {
            return new PlayerEntity
            {
                Id = 0,
                Name = dto.Name,
                Email = dto.Email,
                User = dto.User,
                Password = dto.Password,
                Created_At = null,
                Updated_At = null
            };
        }

        public PlayerEntity MapperToEntity(PlayerPutDto dto)
        {
            return new PlayerEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                User = dto.User,
                Password = dto.Password,
                Created_At = null,
                Updated_At = null
            };
        }
    }
}
