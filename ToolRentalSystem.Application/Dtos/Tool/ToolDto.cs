namespace ToolRentalSystem.Application.Dtos.Tool
{
    public class ToolDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal PricePerDay { get; set; }
        public bool IsAvailable { get; set; }
    }
}