using ToolRentalSystem.Application.Contract;
using ToolRentalSystem.Application.Dtos.Tool;
using ToolRentalSystem.Domain.Core.Entities;
using ToolRentalSystem.Domain.Core.Interfaces;

namespace ToolRentalSystem.Application.Services
{
    public class ToolService : IToolService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ToolService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ToolDto>> GetAllAsync()
        {
            var tools = await _unitOfWork.Tools.GetAllAsync();
            return tools.Select(t => new ToolDto
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                PricePerDay = t.PricePerDay,
                IsAvailable = t.IsAvailable
            });
        }

        public async Task<ToolDto?> GetByIdAsync(int id)
        {
            var tool = await _unitOfWork.Tools.GetByIdAsync(id);
            if (tool == null) return null;
            return new ToolDto
            {
                Id = tool.Id,
                Name = tool.Name,
                Description = tool.Description,
                PricePerDay = tool.PricePerDay,
                IsAvailable = tool.IsAvailable
            };
        }

        public async Task<ToolDto> CreateAsync(CreateToolDto dto)
        {
            var tool = new Tool
            {
                Name = dto.Name,
                Description = dto.Description,
                PricePerDay = dto.PricePerDay
            };
            await _unitOfWork.Tools.AddAsync(tool);
            await _unitOfWork.SaveChangesAsync();
            return new ToolDto
            {
                Id = tool.Id,
                Name = tool.Name,
                Description = tool.Description,
                PricePerDay = tool.PricePerDay,
                IsAvailable = tool.IsAvailable
            };
        }

        public async Task UpdateAsync(int id, CreateToolDto dto)
        {
            var tool = await _unitOfWork.Tools.GetByIdAsync(id);
            if (tool == null) throw new Exception($"Tool with id {id} not found");
            tool.Name = dto.Name;
            tool.Description = dto.Description;
            tool.PricePerDay = dto.PricePerDay;
            await _unitOfWork.Tools.UpdateAsync(tool);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Tools.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}