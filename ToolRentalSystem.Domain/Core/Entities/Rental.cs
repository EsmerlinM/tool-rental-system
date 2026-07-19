namespace ToolRentalSystem.Domain.Core.Entities
{
    public class Rental : BaseEntity
    {
        public int CustomerId { get; set; }
        public int ToolId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsReturned { get; set; } = false;
        public Customer? Customer { get; set; }
        public Tool? Tool { get; set; }
    }
}