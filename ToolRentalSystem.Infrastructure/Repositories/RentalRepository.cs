using Microsoft.EntityFrameworkCore;
using ToolRentalSystem.Domain.Core.Entities;
using ToolRentalSystem.Domain.Core.Interfaces;
using ToolRentalSystem.Infrastructure.Context;

namespace ToolRentalSystem.Infrastructure.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly AppDbContext _context;

        public RentalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rental>> GetAllAsync() =>
            await _context.Rentals.ToListAsync();

        public async Task<Rental?> GetByIdAsync(int id) =>
            await _context.Rentals.FindAsync(id);

        public async Task AddAsync(Rental rental) =>
            await _context.Rentals.AddAsync(rental);

        public async Task UpdateAsync(Rental rental) =>
            _context.Rentals.Update(rental);

        public async Task DeleteAsync(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental != null) _context.Rentals.Remove(rental);
        }
    }
}