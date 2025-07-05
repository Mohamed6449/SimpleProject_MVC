using MCV_Empity.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCV_Empity.ViewModels.Products
{
    public class AddProductViewModels
    {

        [Required(ErrorMessage = "NameArIsRequired")]
        [Remote("IsProductNameExist", "product", HttpMethod = "Post", ErrorMessage = "name exists")]
        public string NameAr { get; set; }

        [Required(ErrorMessage = "NameEnIsRequired")]
        public string NameEn { get; set; }
        [Range(2, 4999, ErrorMessage = "number must be in range ")]
        public decimal Price { get; set; }
        [NotMapped]
        public List<IFormFile>? Files { get; set; }
        public int CategoryId { get; set; }




    }
}
