using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCV_Empity.Models
{
    public class product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(2,4999,ErrorMessage ="number must be in range ") ]
        [Required]
        public decimal Price { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }

        public string? path { get; set; }
    }
}
