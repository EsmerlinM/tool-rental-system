namespace ToolRentalSystem.Application.Dtos.Rental
{
    public class RentalDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ToolId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsReturned { get; set; }
    }
}