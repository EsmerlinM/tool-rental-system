using System.ComponentModel.DataAnnotations;

namespace ToolRentalSystem.Application.Dtos.Rental
{
    public class CreateRentalDto
    {
        [Required(ErrorMessage = "Customer is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid customer ID")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Tool is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid tool ID")]
        public int ToolId { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }
    }
}