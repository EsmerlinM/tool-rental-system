using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolRentalSystem.Data;
using ToolRentalSystem.DTOs;
using ToolRentalSystem.Models;

namespace ToolRentalSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaymentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> GetAll()
        {
            var payments = await _context.Payments.ToListAsync();
            return Ok(payments.Select(p => new PaymentDto
            {
                Id = p.Id,
                RentalId = p.RentalId,
                Amount = p.Amount,
                PaymentDate = p.PaymentDate,
                HasLateFee = p.HasLateFee
            }));
        }

        // GET: api/payments/1
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDto>> GetById(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null) return NotFound();
            return Ok(new PaymentDto
            {
                Id = payment.Id,
                RentalId = payment.RentalId,
                Amount = payment.Amount,
                PaymentDate = payment.PaymentDate,
                HasLateFee = payment.HasLateFee
            });
        }

        // POST: api/payments
        [HttpPost]
        public async Task<ActionResult<PaymentDto>> Create(CreatePaymentDto dto)
        {
            var payment = new Payment
            {
                RentalId = dto.RentalId,
                Amount = dto.Amount,
                PaymentDate = dto.PaymentDate,
                HasLateFee = dto.HasLateFee
            };
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = payment.Id }, payment);
        }

        // PUT: api/payments/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreatePaymentDto dto)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null) return NotFound();
            payment.RentalId = dto.RentalId;
            payment.Amount = dto.Amount;
            payment.PaymentDate = dto.PaymentDate;
            payment.HasLateFee = dto.HasLateFee;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/payments/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null) return NotFound();
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}