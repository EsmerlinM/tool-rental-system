using System.ComponentModel.DataAnnotations;

namespace ToolRentalSystem.Application.Dtos.Tool
{
    public class CreateToolDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price per day is required")]
        [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10000")]
        public decimal PricePerDay { get; set; }
    }
}