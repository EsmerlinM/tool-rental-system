using ToolRentalSystem.Application.Dtos.Payment;

namespace ToolRentalSystem.Application.Contract
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetAllAsync();
        Task<PaymentDto?> GetByIdAsync(int id);
        Task<PaymentDto> CreateAsync(CreatePaymentDto dto);
        Task UpdateAsync(int id, CreatePaymentDto dto);
        Task DeleteAsync(int id);
    }
}