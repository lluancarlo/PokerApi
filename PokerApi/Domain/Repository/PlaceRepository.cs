using Microsoft.EntityFrameworkCore;
using PokerApi.Data;
using PokerApi.Domain.Interfaces;
using PokerApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerApi.Domain.Repository
{
    public class PlaceRepository : GenericRepository, IPlaceRepository
    {
        public PlaceRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<PlaceEntity>> GetAllAsync()
        {
            return await _context.Places.ToListAsync();
        }

        public async Task<PlaceEntity> GetByIdAsync(int placeId)
        {
            return await _context.Places.FirstOrDefaultAsync(f => f.Id == placeId);
        }

        public async Task PostAsync(PlaceEntity place)
        {
            await _context.Places.AddAsync(place);
        }

        public async Task PutAsync(PlaceEntity place)
        {
            await Task.Run(() => _context.Entry(place).State = EntityState.Modified);
        }

        public async Task DeleteAsync(int placeId)
        {
            var place = await GetByIdAsync(placeId);
            await Task.Run(() => _context.Places.Remove(place));
        }
    }
}
