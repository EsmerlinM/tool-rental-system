using ToolRentalSystem.Domain.Core.Entities;
using ToolRentalSystem.Domain.Core.Interfaces;
using ToolRentalSystem.Infrastructure.Context;
using ToolRentalSystem.Infrastructure.Core;

namespace ToolRentalSystem.Infrastructure.Repositories
{
    public class RentalRepository : BaseRepository<Rental>, IRentalRepository
    {
        public RentalRepository(AppDbContext context) : base(context)
        {
        }
    }
}