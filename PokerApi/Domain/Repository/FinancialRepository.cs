using Microsoft.EntityFrameworkCore;
using PokerApi.Data;
using PokerApi.Domain.Interfaces;
using PokerApi.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokerApi.Domain.Repository
{
    public class FinancialRepository : GenericRepository, IFinancialRepository
    {
        public FinancialRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<FinancialEntity>> GetAllAsync()
        {
            return await _context.Financial.ToListAsync();
        }

        public async Task<FinancialEntity> GetByIdAsync(int playerId, int placeId)
        {
            return await _context.Financial.FirstOrDefaultAsync(f => f.PlayerId == playerId && f.PlaceId == placeId);
        }

        public async Task PostAsync(FinancialEntity financial)
        {
            await _context.Financial.AddAsync(financial);
        }

        public async Task PutAsync(FinancialEntity financial)
        {
            await Task.Run(() => _context.Entry(financial).State = EntityState.Modified);
        }

        public async Task DeleteAsync(int playerId, int placeId)
        {
            var financial = await GetByIdAsync(playerId, placeId);
            await Task.Run(() => _context.Financial.Remove(financial));
        }
    }
}
