namespace MCV_Empity.Models
{
	public class Category
	{
		public int Id { get; set; }

		public string? Name { get; set; }

		public  ICollection< product >product { get; set; }=new HashSet<product>();
	}
}
