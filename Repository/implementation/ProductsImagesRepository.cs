using MCV_Empity.Data;
using MCV_Empity.Models;
using MCV_Empity.Repository.Interface;
using MCV_Empity.SharedRepository;
using Microsoft.EntityFrameworkCore;

namespace MCV_Empity.Repository.implementation
{
	public class ProductsImagesRepository:GenericRepository<ProductImages>,IProductsImagesRepository
	{
		private readonly DbSet<ProductImages>_ProductImages;
		public ProductsImagesRepository(AppDbContect appDbContect ): base(appDbContect)
		{
			_ProductImages = appDbContect.Set<ProductImages>();
		}

	}
}
