using MCV_Empity.Helper;

namespace MCV_Empity.Models
{
	public class Category:LocalizableEntity
	{
		public int Id { get; set; }

		public string? NameAr { get; set; }
		public string? NameEn { get; set; }

		public  ICollection< product >product { get; set; }=new HashSet<product>();
	}
}
