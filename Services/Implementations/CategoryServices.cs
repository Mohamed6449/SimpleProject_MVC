using MCV_Empity.Data;
using MCV_Empity.Models;
using MCV_Empity.Services.InterFaces;
using Microsoft.EntityFrameworkCore;

namespace MCV_Empity.Services.Implementations
{
	public class CategoryServices : ICategoryServices
	{
		private readonly AppDbContect _appDbContect;

		public CategoryServices(AppDbContect appDbContect) {
		
			_appDbContect=appDbContect;
		}
		public async Task< List<Category>> GetCategories()
		{
			return await _appDbContect.Category.ToListAsync();
		}
	}
}
