using MCV_Empity.Models;

namespace MCV_Empity.Services.InterFaces
{
	public interface ICategoryServices
	{
		public Task< List<Category> >GetCategories();
	}
}
