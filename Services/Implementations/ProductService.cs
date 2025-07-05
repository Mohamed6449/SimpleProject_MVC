using MCV_Empity.Data;
using MCV_Empity.Models;
using MCV_Empity.Repository.Interface;
using MCV_Empity.Services.InterFaces;
using MCV_Empity.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace MCV_Empity.Services.Implementations
{
	public class ProductService : IProductService
	{
		#region Fields

		private IFileServiece _fileServiece;

		#endregion

		private IUnitOfWork _unitOfWork;
		#region Constructors
		public ProductService(IFileServiece fileServiece,IUnitOfWork unitOfWork)
		{
			_fileServiece = fileServiece;
			_unitOfWork = unitOfWork;

		}


		#endregion

		public async Task<string> AddProduct(product product, List<IFormFile>? Files)
		{
			var Paths = new List<string>();
			var ap = await _unitOfWork.BeginTransactionAsync();
			try
			{
				if (Files != null && Files.Count > 0)
				{
					var productimage = new List<ProductImages>();
					foreach (var item in Files)
					{
						string paths = await _fileServiece.Upload(item, "/image/");
						productimage.Add(new ProductImages() { path = paths });
						Paths.Add(paths);
					}


					product.ProductImages = productimage;
				}
				await _unitOfWork.Repository<product>().AddAsync(product);
				await ap.CommitAsync();
				return "Success";

			}
			catch (Exception ex)
			{
				await ap.RollbackAsync();
				foreach (var item in Paths)
				{
					_fileServiece.DeleteSource(item);
				}
				return ex.Message + "--" + ex.InnerException;
			}


		}

		public async Task<string> DeleteProduct(product productR)
		{
			try
			{

				//string path = productR.path;
				await _unitOfWork.Repository<product>().DeleteAsync(productR);
					
					//_fileServiece.DeleteSource(productR.ProductImages);
				return "Success";
			}

			catch (Exception ex)
			{
				return ex.Message + "--" + ex.InnerException;
			}
		}

		public async Task<product?> GetProductById(int ProductId)
		{

			return await _unitOfWork.Repository<product>().GetAsQueryble().Include(I => I.ProductImages).AsNoTracking().FirstOrDefaultAsync(F => F.Id == ProductId);

		}
		public async Task<product?> GetProductByIdWithOutInclude(int ProductId)
		{

			return await _unitOfWork.Repository<product>().GetProductbyIdAsync(ProductId);

		}

		public async Task<List<product>> GetProducts()
		{
			return await _unitOfWork.Repository<product>().GetAsListAsync();
		}

		public async Task<bool> IsProductNameArExist(string Name)
		{
			var b = await _unitOfWork.Repository<product>().GetAsQueryble().AnyAsync(A => A.NameAr == Name);
			return b;
		}
		public async Task<bool> IsProductNameEnExist(string NameEn)
		{
			var b = await _unitOfWork.Repository<product>().GetAsQueryble().AnyAsync(A => A.NameEn == NameEn);
			return b;
		}

		public async Task<string> UpdateProduct(product product, List<IFormFile> Files)
		{

			var Paths = new List<string>();
			var ap = await _unitOfWork.Repository<product>().BeginTransactionAsync();
			try
			{
				if (Files != null && Files.Count > 0)
				{
					var paths2 = await _unitOfWork.Repository<ProductImages>().GetAsQueryble().Where(W => W.productId == product.Id).ToListAsync();

					if (paths2 != null)
					{
						_unitOfWork.Repository<ProductImages>().DeleteRangeAsync(paths2);

						foreach (var item2 in paths2)
						{
							_fileServiece.DeleteSource(item2.path);

						}
					}

					var productimage = new List<ProductImages>();
					foreach (var item in Files)
					{
						string path = await _fileServiece.Upload(item, "/image/");
						productimage.Add(new ProductImages() { path = path });
						Paths.Add(path);
					}


					product.ProductImages = productimage;
				}
                _unitOfWork.Repository<product>().UpdateAsync(product);
				await ap.CommitAsync();
				return "Success";


			}
			catch (Exception ex)
			{
				await ap.RollbackAsync();
				foreach (var item in Paths)
				{
					_fileServiece.DeleteSource(item);
				}
				return ex.Message + "--" + ex.InnerException;
			}
		}

		public IQueryable<product> GetProductsAsQerayable(string? search)
		{
			var products = _unitOfWork.Repository<product>().GetAsQueryble();
			if (search != null)
			{
				products = products.Where(W => W.NameAr.Contains(search)|| W.NameEn.Contains(search));
			}
			return products;


		}
	}
}
