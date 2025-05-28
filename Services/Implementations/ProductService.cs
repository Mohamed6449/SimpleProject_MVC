using MCV_Empity.Data;
using MCV_Empity.Models;
using MCV_Empity.Services.InterFaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MCV_Empity.Services.Implementations
{
	public class ProductService : IProductService
	{
		#region Fields
		private readonly AppDbContect _appDbContext;
		private IFileServiece _fileServiece;
		
		#endregion
		

		#region Constructors
		public ProductService(IFileServiece fileServiece,AppDbContect appDbContect) {

			_appDbContext = appDbContect;
			_fileServiece = fileServiece;

		
		}


		#endregion

		#region Implement Functions
		public async Task<string> AddProduct(product product)
		{
			try
			{
				product.Id = await _appDbContext.Products.MaxAsync(M => M.Id) + 1;
				await _appDbContext.Products.AddAsync(product);
				await _appDbContext.SaveChangesAsync();
				return "Success";

			}
			catch (Exception ex)
			{
				return ex.Message+"--"+ex.InnerException;
			}

			
		}

		public async Task<string> DeleteProduct(int ProductId)
		{
			try
			{

			string path="";
			var resul = await GetProductById(ProductId);
			if (resul != null)
			{
				path =resul.path;
				_appDbContext.Products.Remove(resul);
				await _appDbContext.SaveChangesAsync();
			}
			_fileServiece.DeleteSource(path);
				return "Success";
			}
			catch (Exception ex)
			{
				return ex.Message + "--" + ex.InnerException;
			}
		}

		public async Task< product?> GetProductById(int ProductId)
		{

			return await _appDbContext.Products.FindAsync(ProductId);

		}

		public async Task< List<product> >GetProducts()
		{
			return await _appDbContext.Products.ToListAsync();
		}

		public async Task<string> UpdateProduct(product product)
		{
			try
			{
				var resul = await GetProductById(product.Id);
				if (resul != null)
				{
					resul.Name = product.Name;
					resul.Price = product.Price;
					resul.path = product.path;
					_appDbContext.Products.Update(resul);
					await _appDbContext.SaveChangesAsync();
					return "Success";
				}
				return "faild";

			}
			catch (Exception ex)
			{
				return ex.Message + "--" + ex.InnerException;
			}

		}


	

		#endregion


	}
}
