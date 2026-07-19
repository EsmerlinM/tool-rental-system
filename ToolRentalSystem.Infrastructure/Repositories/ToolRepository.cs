using ToolRentalSystem.Domain.Core.Entities;
using ToolRentalSystem.Domain.Core.Interfaces;
using ToolRentalSystem.Infrastructure.Context;
using ToolRentalSystem.Infrastructure.Core;

namespace ToolRentalSystem.Infrastructure.Repositories
{
    public class ToolRepository : BaseRepository<Tool>, IToolRepository
    {
        public ToolRepository(AppDbContext context) : base(context)
        {
        }
    }
}