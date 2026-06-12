using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolRentalSystem.Data;
using ToolRentalSystem.DTOs;
using ToolRentalSystem.Models;

namespace ToolRentalSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToolsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ToolsController(AppDbContext context)
        {
            _context = context;
        }

      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToolDto>>> GetAll()
        {
            var tools = await _context.Tools.ToListAsync();
            return Ok(tools.Select(t => new ToolDto
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                PricePerDay = t.PricePerDay,
                IsAvailable = t.IsAvailable
            }));
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<ToolDto>> GetById(int id)
        {
            var tool = await _context.Tools.FindAsync(id);
            if (tool == null) return NotFound();
            return Ok(new ToolDto
            {
                Id = tool.Id,
                Name = tool.Name,
                Description = tool.Description,
                PricePerDay = tool.PricePerDay,
                IsAvailable = tool.IsAvailable
            });
        }

       
        [HttpPost]
        public async Task<ActionResult<ToolDto>> Create(CreateToolDto dto)
        {
            var tool = new Tool
            {
                Name = dto.Name,
                Description = dto.Description,
                PricePerDay = dto.PricePerDay
            };
            _context.Tools.Add(tool);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = tool.Id }, tool);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateToolDto dto)
        {
            var tool = await _context.Tools.FindAsync(id);
            if (tool == null) return NotFound();
            tool.Name = dto.Name;
            tool.Description = dto.Description;
            tool.PricePerDay = dto.PricePerDay;
            await _context.SaveChangesAsync();
            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tool = await _context.Tools.FindAsync(id);
            if (tool == null) return NotFound();
            _context.Tools.Remove(tool);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
