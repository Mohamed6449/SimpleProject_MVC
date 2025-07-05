using MCV_Empity.Data;
using MCV_Empity.Models;
using MCV_Empity.Repository.Interface;
using MCV_Empity.SharedRepository;

namespace MCV_Empity.Repository.implementation
{
	public class CategoryRepository:GenericRepository<Category> ,ICategoryRepository
	{
		public CategoryRepository(AppDbContect appContext):base(appContext)
		{

		}

	}
}
