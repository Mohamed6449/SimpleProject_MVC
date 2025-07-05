using MCV_Empity.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCV_Empity.Models
{
    public class ProductImages: LocalizableEntity
    {
        [Key]
        public int Id { get; set; }

        public string? path { get; set; }

        [ForeignKey("product")]
        public int productId { get; set; }
        
        public product? product { get; set; }
    }
}
