namespace ToolRentalSystem.Domain.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IToolRepository Tools { get; }
        ICustomerRepository Customers { get; }
        IRentalRepository Rentals { get; }
        IPaymentRepository Payments { get; }
        Task<int> SaveChangesAsync();
    }
}