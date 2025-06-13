﻿using MCV_Empity.Data;
using MCV_Empity.Models;
using MCV_Empity.Services.InterFaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

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
		public async Task<string> AddProduct(product product,List<IFormFile>? Files)
		{
			var  Paths = new List<string>();
			var ap =await _appDbContext.Database.BeginTransactionAsync();
			try
			{
				if (Files!=null&& Files.Count > 0)
				{
				var productimage = new List<ProductImages>();
					foreach (var item in Files)
					{
						string paths = await _fileServiece.Upload(item, "/image/");
						productimage.Add(new ProductImages() { path=paths});
						Paths.Add(paths);
					}


				product.ProductImages = productimage;
				}
				await _appDbContext.Products.AddAsync(product);
				await _appDbContext.SaveChangesAsync();
				await ap.CommitAsync();
				return "Success";

			}
			catch (Exception ex)
			{
				await ap.RollbackAsync();
				foreach(var item in Paths)
				{
					_fileServiece.DeleteSource(item);
				}
				return ex.Message+"--"+ex.InnerException;
			}

			
		}

		public async Task<string> DeleteProduct(product productR)
		{
			try
			{
				
				//string path = productR.path;
				_appDbContext.Products.Remove(productR);
				_ = await _appDbContext.SaveChangesAsync();
				//_fileServiece.DeleteSource(path);
				return "Success";
			}
			
			catch (Exception ex)
			{
				return ex.Message + "--" + ex.InnerException;
			}
		}

		public async Task< product?> GetProductById(int ProductId)
		{

			return await _appDbContext.Products.AsNoTracking().FirstOrDefaultAsync(F=>F.Id== ProductId);

		}

		public async Task< List<product> >GetProducts()
		{
			return await _appDbContext.Products.ToListAsync();
		}

		public async Task<bool> IsProductNameExist(string Name)
		{
			var b= await _appDbContext.Products.AnyAsync(A => A.Name == Name);
			return b;
		}

		public async Task<string> UpdateProduct(product product)
		{
			try
			{

					_appDbContext.Products.Update(product);
					await _appDbContext.SaveChangesAsync();
					return "Success";


			}
			catch (Exception ex)
			{
				return ex.Message + "--" + ex.InnerException;
			}

		}


	

		#endregion


	}
}
