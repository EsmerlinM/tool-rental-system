using ToolRentalSystem.Application.Contract;
using ToolRentalSystem.Application.Dtos.Payment;
using ToolRentalSystem.Domain.Core.Entities;
using ToolRentalSystem.Domain.Core.Interfaces;

namespace ToolRentalSystem.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PaymentDto>> GetAllAsync()
        {
            var payments = await _unitOfWork.Payments.GetAllAsync();
            return payments.Select(p => new PaymentDto
            {
                Id = p.Id,
                RentalId = p.RentalId,
                Amount = p.Amount,
                PaymentDate = p.PaymentDate,
                HasLateFee = p.HasLateFee
            });
        }

        public async Task<PaymentDto?> GetByIdAsync(int id)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(id);
            if (payment == null) return null;
            return new PaymentDto
            {
                Id = payment.Id,
                RentalId = payment.RentalId,
                Amount = payment.Amount,
                PaymentDate = payment.PaymentDate,
                HasLateFee = payment.HasLateFee
            };
        }

        public async Task<PaymentDto> CreateAsync(CreatePaymentDto dto)
        {
            var payment = new Payment
            {
                RentalId = dto.RentalId,
                Amount = dto.Amount,
                PaymentDate = dto.PaymentDate,
                HasLateFee = dto.HasLateFee
            };
            await _unitOfWork.Payments.AddAsync(payment);
            await _unitOfWork.SaveChangesAsync();
            return new PaymentDto
            {
                Id = payment.Id,
                RentalId = payment.RentalId,
                Amount = payment.Amount,
                PaymentDate = payment.PaymentDate,
                HasLateFee = payment.HasLateFee
            };
        }

        public async Task UpdateAsync(int id, CreatePaymentDto dto)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(id);
            if (payment == null) throw new Exception($"Payment with id {id} not found");
            payment.RentalId = dto.RentalId;
            payment.Amount = dto.Amount;
            payment.PaymentDate = dto.PaymentDate;
            payment.HasLateFee = dto.HasLateFee;
            await _unitOfWork.Payments.UpdateAsync(payment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Payments.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}