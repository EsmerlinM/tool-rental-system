using Microsoft.EntityFrameworkCore;
using ToolRentalSystem.Domain.Core.Entities;
using ToolRentalSystem.Domain.Core.Interfaces;
using ToolRentalSystem.Infrastructure.Context;

namespace ToolRentalSystem.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync() =>
            await _context.Payments.ToListAsync();

        public async Task<Payment?> GetByIdAsync(int id) =>
            await _context.Payments.FindAsync(id);

        public async Task AddAsync(Payment payment) =>
            await _context.Payments.AddAsync(payment);

        public async Task UpdateAsync(Payment payment) =>
            _context.Payments.Update(payment);

        public async Task DeleteAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment != null) _context.Payments.Remove(payment);
        }
    }
}