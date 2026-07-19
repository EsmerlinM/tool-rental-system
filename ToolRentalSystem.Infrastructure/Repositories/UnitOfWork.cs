using ToolRentalSystem.Domain.Core.Interfaces;
using ToolRentalSystem.Infrastructure.Context;

namespace ToolRentalSystem.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IToolRepository Tools { get; }
        public ICustomerRepository Customers { get; }
        public IRentalRepository Rentals { get; }
        public IPaymentRepository Payments { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Tools = new ToolRepository(context);
            Customers = new CustomerRepository(context);
            Rentals = new RentalRepository(context);
            Payments = new PaymentRepository(context);
        }

        public async Task<int> SaveChangesAsync() =>
            await _context.SaveChangesAsync();

        public void Dispose() =>
            _context.Dispose();
    }
}