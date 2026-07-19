using ToolRentalSystem.Application.Dtos.Tool;

namespace ToolRentalSystem.Application.Contract
{
    public interface IToolService
    {
        Task<IEnumerable<ToolDto>> GetAllAsync();
        Task<ToolDto?> GetByIdAsync(int id);
        Task<ToolDto> CreateAsync(CreateToolDto dto);
        Task UpdateAsync(int id, CreateToolDto dto);
        Task DeleteAsync(int id);
    }
}