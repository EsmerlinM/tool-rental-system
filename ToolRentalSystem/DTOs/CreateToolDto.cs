namespace ToolRentalSystem.DTOs
{
    public class CreateToolDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal PricePerDay { get; set; }
    }
}
