using MCV_Empity.Helper;

namespace MCV_Empity.Models.Identity
{
	public class Claim : LocalizableEntity

	{
		public int Id { get; set; }

		public string NameAr { get; set; }
		public string NameEn { get; set; }

		public bool IsUserClaim { get; set; } = true;
		public bool IsRoleClaim { get; set; } = true;





	}
}
