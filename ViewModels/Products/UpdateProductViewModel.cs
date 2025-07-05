using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MCV_Empity.ViewModels.Products
{
    public class UpdateProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "NameArIsRequired")]
        public string NameAr { get; set; }

        [Required(ErrorMessage = "NameEnIsRequired")]
        public string NameEn { get; set; }
        [Range(2, 4999, ErrorMessage = "number must be in range ")]
        public decimal Price { get; set; }
        [NotMapped]
        public List<IFormFile>? Files { get; set; }

        public List<string>? CurrentPaths { get; set; }
        public int CategoryId { get; set; }


    }
}
