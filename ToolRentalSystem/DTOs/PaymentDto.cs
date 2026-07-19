using System.ComponentModel.DataAnnotations.Schema;

namespace ToolRentalSystem.DTOs
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int RentalId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool HasLateFee { get; set; }
    }
}