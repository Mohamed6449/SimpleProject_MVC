using System.ComponentModel.DataAnnotations;

namespace MCV_Empity.ViewModels.Identity.Users
{
	public class GetUsersListViewModel
	{
		[Required]
		public string Id { get; set; }

		public string Name { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }


	}
}
