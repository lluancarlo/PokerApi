using PokerApi.Business.Interfaces.Mappers;
using PokerApi.Business.Interfaces.Service;
using PokerApi.Domain.Interfaces;
using PokerApi.Model.Dto.Financial;
using PokerApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokerApi.Business.Services
{
    public class FinancialBusiness : IFinancialBusiness
    {
        private readonly IFinancialRepository _repository;
        private readonly IFinancialMapper _mapper;

        public FinancialBusiness(IFinancialRepository repository, IFinancialMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FinancialEntity>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<FinancialEntity> GetById(int playerId, int placeId)
        {
            return await _repository.GetByIdAsync(playerId, placeId);
        }

        public async Task<FinancialEntity> Post(FinancialPostDto financial)
        {
            FinancialEntity financialEntity = _mapper.MapperToEntity(financial);
            financialEntity.Created_At = DateTime.Now;

            await _repository.PostAsync(financialEntity);
            await _repository.CommitAsync();

            return financialEntity;
        }

        public async Task Put(int playerId, int placeId, FinancialPutDto financial)
        {
            FinancialEntity financialEntity = _mapper.MapperToEntity(financial);

            var result = await _repository.GetByIdAsync(playerId, placeId);
            result.Balance = financialEntity.Balance;
            result.Updated_At = DateTime.Now;
            
            await _repository.PutAsync(result);
            await _repository.CommitAsync();
        }

        public async Task Delete(int playerId, int placeId)
        {
            await _repository.DeleteAsync(playerId, placeId);
            await _repository.CommitAsync(); ;
        }
    }
}
