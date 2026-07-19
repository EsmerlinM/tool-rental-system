using ToolRentalSystem.Application.Contract;
using ToolRentalSystem.Application.Dtos.Rental;
using ToolRentalSystem.Domain.Core.Entities;
using ToolRentalSystem.Domain.Core.Interfaces;

namespace ToolRentalSystem.Application.Services
{
    public class RentalService : IRentalService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RentalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<RentalDto>> GetAllAsync()
        {
            var rentals = await _unitOfWork.Rentals.GetAllAsync();
            return rentals.Select(r => new RentalDto
            {
                Id = r.Id,
                CustomerId = r.CustomerId,
                ToolId = r.ToolId,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                IsReturned = r.IsReturned
            });
        }

        public async Task<RentalDto?> GetByIdAsync(int id)
        {
            var rental = await _unitOfWork.Rentals.GetByIdAsync(id);
            if (rental == null) return null;
            return new RentalDto
            {
                Id = rental.Id,
                CustomerId = rental.CustomerId,
                ToolId = rental.ToolId,
                StartDate = rental.StartDate,
                EndDate = rental.EndDate,
                IsReturned = rental.IsReturned
            };
        }

        public async Task<RentalDto> CreateAsync(CreateRentalDto dto)
        {
            var rental = new Rental
            {
                CustomerId = dto.CustomerId,
                ToolId = dto.ToolId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate
            };
            await _unitOfWork.Rentals.AddAsync(rental);
            await _unitOfWork.SaveChangesAsync();
            return new RentalDto
            {
                Id = rental.Id,
                CustomerId = rental.CustomerId,
                ToolId = rental.ToolId,
                StartDate = rental.StartDate,
                EndDate = rental.EndDate,
                IsReturned = rental.IsReturned
            };
        }

        public async Task UpdateAsync(int id, CreateRentalDto dto)
        {
            var rental = await _unitOfWork.Rentals.GetByIdAsync(id);
            if (rental == null) throw new Exception($"Rental with id {id} not found");
            rental.CustomerId = dto.CustomerId;
            rental.ToolId = dto.ToolId;
            rental.StartDate = dto.StartDate;
            rental.EndDate = dto.EndDate;
            await _unitOfWork.Rentals.UpdateAsync(rental);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Rentals.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}