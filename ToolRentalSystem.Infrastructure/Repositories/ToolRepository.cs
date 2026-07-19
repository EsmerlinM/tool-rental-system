using Microsoft.EntityFrameworkCore;
using ToolRentalSystem.Domain.Core.Entities;
using ToolRentalSystem.Domain.Core.Interfaces;
using ToolRentalSystem.Infrastructure.Context;

namespace ToolRentalSystem.Infrastructure.Repositories
{
    public class ToolRepository : IToolRepository
    {
        private readonly AppDbContext _context;

        public ToolRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tool>> GetAllAsync() =>
            await _context.Tools.ToListAsync();

        public async Task<Tool?> GetByIdAsync(int id) =>
            await _context.Tools.FindAsync(id);

        public async Task AddAsync(Tool tool) =>
            await _context.Tools.AddAsync(tool);

        public async Task UpdateAsync(Tool tool) =>
            _context.Tools.Update(tool);

        public async Task DeleteAsync(int id)
        {
            var tool = await _context.Tools.FindAsync(id);
            if (tool != null) _context.Tools.Remove(tool);
        }
    }
}