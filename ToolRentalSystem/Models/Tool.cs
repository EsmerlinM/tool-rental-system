using System.ComponentModel.DataAnnotations.Schema;

namespace ToolRentalSystem.Models
{
    public class Tool
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerDay { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
