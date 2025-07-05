using MCV_Empity.Data;
using MCV_Empity.Models;
using MCV_Empity.Repository.Interface;
using MCV_Empity.Services.InterFaces;
using MCV_Empity.SharedRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace MCV_Empity.Repository.implementation
{
	public class ProductRepository : GenericRepository<product>, IProductRepository 
	{
		

		private readonly DbSet<product> _product;
		public ProductRepository(AppDbContect appDbContext):base(appDbContext)
		{
			_product = appDbContext.Set<product>();
		}

	
	}
}
