using MCV_Empity.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCV_Empity.ViewModels
{
	public class AddProductViewModels
	{

        [Required]
        [Remote("IsProductNameExist", "product", HttpMethod = "Post", ErrorMessage = "name exists")]
        public string Name { get; set; }
        [Range(2, 4999, ErrorMessage = "number must be in range ")]
        public decimal Price { get; set; }
        [NotMapped]
        public List<IFormFile>? Files { get; set; }
        public int CategoryId { get; set; }




    }
}
