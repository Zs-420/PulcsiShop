using System.ComponentModel.DataAnnotations;

namespace PulcsiShop.Models
{
    public class Size
    {      
         public int SizeId { get; set; }
         public string? SizeDes { get; set; }
         public virtual ICollection<Pulcsi> Pulcsik { get; set; }
    }
}
