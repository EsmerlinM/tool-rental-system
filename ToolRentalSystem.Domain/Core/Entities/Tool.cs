namespace ToolRentalSystem.Domain.Core.Entities
{
    public class Tool : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal PricePerDay { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}