using ToolRentalSystem.Domain.Core.Entities;
using ToolRentalSystem.Domain.Core.Interfaces;
using ToolRentalSystem.Infrastructure.Context;
using ToolRentalSystem.Infrastructure.Core;

namespace ToolRentalSystem.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }
    }
}