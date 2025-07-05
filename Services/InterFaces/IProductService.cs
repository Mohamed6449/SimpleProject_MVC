using MCV_Empity.Models;

namespace MCV_Empity.Services.InterFaces
{
	public interface IProductService
	{
		public IQueryable<product> GetProductsAsQerayable(string? search);
		public Task<product?> GetProductById(int ProductId);
		public Task<string> AddProduct(product product, List<IFormFile>? Files);
		public Task<string> UpdateProduct(product product,List<IFormFile> formFiles);
		public Task<string> DeleteProduct(product ProductId);
		public Task<product?> GetProductByIdWithOutInclude(int ProductId);

        public Task<bool> IsProductNameArExist(string Name);
		public Task<bool> IsProductNameEnExist(string Name);



	}
}
