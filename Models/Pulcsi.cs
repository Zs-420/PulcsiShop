using System.ComponentModel.DataAnnotations.Schema;
namespace PulcsiShop.Models
{
    public class Pulcsi
    {
        public long PulcsiID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        public Size? Size { get; set; }
    }
}
