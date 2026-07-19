using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolRentalSystem.Data;
using ToolRentalSystem.DTOs;
using ToolRentalSystem.Models;

namespace ToolRentalSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RentalsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/rentals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalDto>>> GetAll()
        {
            var rentals = await _context.Rentals.ToListAsync();
            return Ok(rentals.Select(r => new RentalDto
            {
                Id = r.Id,
                CustomerId = r.CustomerId,
                ToolId = r.ToolId,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                IsReturned = r.IsReturned
            }));
        }

        // GET: api/rentals/1
        [HttpGet("{id}")]
        public async Task<ActionResult<RentalDto>> GetById(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null) return NotFound();
            return Ok(new RentalDto
            {
                Id = rental.Id,
                CustomerId = rental.CustomerId,
                ToolId = rental.ToolId,
                StartDate = rental.StartDate,
                EndDate = rental.EndDate,
                IsReturned = rental.IsReturned
            });
        }

        // POST: api/rentals
        [HttpPost]
        public async Task<ActionResult<RentalDto>> Create(CreateRentalDto dto)
        {
            var rental = new Rental
            {
                CustomerId = dto.CustomerId,
                ToolId = dto.ToolId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate
            };
            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = rental.Id }, rental);
        }

        // PUT: api/rentals/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateRentalDto dto)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null) return NotFound();
            rental.CustomerId = dto.CustomerId;
            rental.ToolId = dto.ToolId;
            rental.StartDate = dto.StartDate;
            rental.EndDate = dto.EndDate;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/rentals/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null) return NotFound();
            _context.Rentals.Remove(rental);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}