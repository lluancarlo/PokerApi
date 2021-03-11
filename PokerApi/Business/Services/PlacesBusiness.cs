using PokerApi.Business.Interfaces.Mappers;
using PokerApi.Business.Interfaces.Service;
using PokerApi.Domain.Interfaces;
using PokerApi.Model.Dto.Place;
using PokerApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokerApi.Business.Services
{
    public class PlacesBusiness : IPlacesBusiness
    {
        private readonly IPlaceRepository _repository;
        private readonly IPlaceMapper _mapper;

        public PlacesBusiness(IPlaceRepository repository, IPlaceMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlaceEntity>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PlaceEntity> GetById(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }

        public async Task<PlaceEntity> Post(PlacePostDto place)
        {
            PlaceEntity placeEntity = _mapper.MapperToEntity(place);
            placeEntity.Created_At = DateTime.Now;

            await _repository.PostAsync(placeEntity);
            await _repository.CommitAsync();

            return placeEntity;
        }

        public async Task Put(int Id, PlacePutDto place)
        {
            PlaceEntity placeEntity = _mapper.MapperToEntity(place);

            var result = await _repository.GetByIdAsync(Id);
            result.Name = placeEntity.Name;
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
