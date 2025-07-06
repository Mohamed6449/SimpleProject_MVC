using System.ComponentModel.DataAnnotations;

namespace MCV_Empity.ViewModels.Identity
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="The password and Confirmation password not match")]
        public string ConfirmPassword { get; set;}
    
    }
}
