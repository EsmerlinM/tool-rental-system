using ToolRentalSystem.Domain.Core.Entities;

namespace ToolRentalSystem.Domain.Core.Interfaces
{
    public interface IToolRepository
    {
        Task<IEnumerable<Tool>> GetAllAsync();
        Task<Tool?> GetByIdAsync(int id);
        Task AddAsync(Tool tool);
        Task UpdateAsync(Tool tool);
        Task DeleteAsync(int id);
    }
}