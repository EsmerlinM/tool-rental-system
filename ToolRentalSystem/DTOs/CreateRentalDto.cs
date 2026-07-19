namespace ToolRentalSystem.DTOs
{
    public class CreateRentalDto
    {
        public int CustomerId { get; set; }
        public int ToolId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}