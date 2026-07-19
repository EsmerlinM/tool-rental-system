using ToolRentalSystem.Application.Contract;
using ToolRentalSystem.Application.Dtos.Customer;
using ToolRentalSystem.Domain.Core.Entities;
using ToolRentalSystem.Domain.Core.Interfaces;

namespace ToolRentalSystem.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _unitOfWork.Customers.GetAllAsync();
            return customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Phone = c.Phone
            });
        }

        public async Task<CustomerDto?> GetByIdAsync(int id)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);
            if (customer == null) return null;
            return new CustomerDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone
            };
        }

        public async Task<CustomerDto> CreateAsync(CreateCustomerDto dto)
        {
            var customer = new Customer
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone
            };
            await _unitOfWork.Customers.AddAsync(customer);
            await _unitOfWork.SaveChangesAsync();
            return new CustomerDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone
            };
        }

        public async Task UpdateAsync(int id, CreateCustomerDto dto)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);
            if (customer == null) throw new Exception($"Customer with id {id} not found");
            customer.FirstName = dto.FirstName;
            customer.LastName = dto.LastName;
            customer.Email = dto.Email;
            customer.Phone = dto.Phone;
            await _unitOfWork.Customers.UpdateAsync(customer);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Customers.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}