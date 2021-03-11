using PokerApi.Data;
using PokerApi.Domain.Interfaces;
using System.Threading.Tasks;

namespace PokerApi.Domain.Repository
{
    public class GenericRepository : IGenericRepository
    {
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
