using Microsoft.EntityFrameworkCore;
using PokerApi.Data;
using PokerApi.Domain.Interfaces;
using PokerApi.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokerApi.Domain.Repository
{
    public class PlayerRepository : GenericRepository, IPlayerRepository
    {
        public PlayerRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<PlayerEntity>> GetAllAsync()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<PlayerEntity> GetByIdAsync(int playerId)
        {
            return await _context.Players.FirstOrDefaultAsync(f => f.Id == playerId);
        }

        public async Task PostAsync(PlayerEntity player)
        {
            await _context.Players.AddAsync(player);
        }

        public async Task PutAsync(PlayerEntity player)
        {
            await Task.Run(() => _context.Entry(player).State = EntityState.Modified);
        }

        public async Task DeleteAsync(int playerId)
        {
            var player = await GetByIdAsync(playerId);
            await Task.Run(() => _context.Players.Remove(player));
        }
    }
}
