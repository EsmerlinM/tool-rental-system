using System.ComponentModel.DataAnnotations.Schema;
namespace ToolRentalSystem.Domain.Core.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int RentalId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool HasLateFee { get; set; } = false;
        public Rental? Rental { get; set; }
    }
}
