using ToolRentalSystem.Application.Dtos.Rental;

namespace ToolRentalSystem.Application.Contract
{
    public interface IRentalService
    {
        Task<IEnumerable<RentalDto>> GetAllAsync();
        Task<RentalDto?> GetByIdAsync(int id);
        Task<RentalDto> CreateAsync(CreateRentalDto dto);
        Task UpdateAsync(int id, CreateRentalDto dto);
        Task DeleteAsync(int id);
    }
}