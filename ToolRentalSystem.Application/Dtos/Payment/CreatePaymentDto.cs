using System.ComponentModel.DataAnnotations;

namespace ToolRentalSystem.Application.Dtos.Payment
{
    public class CreatePaymentDto
    {
        [Required(ErrorMessage = "Rental is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid rental ID")]
        public int RentalId { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, 100000, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Payment date is required")]
        public DateTime PaymentDate { get; set; }

        public bool HasLateFee { get; set; } = false;
    }
}