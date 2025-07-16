using System.ComponentModel.DataAnnotations;

namespace MCV_Empity.ViewModels.Identity.Roles
{
	public class CreateRoleViewModel
	{
		[Required]
		public string Name { get; set; }
	}
}
