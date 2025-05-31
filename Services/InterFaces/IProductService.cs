using MCV_Empity.Models;

namespace MCV_Empity.Services.InterFaces
{
	public interface IProductService
	{
		public Task<List<product>> GetProducts();
		public Task<product?> GetProductById(int ProductId);
		public Task<string> AddProduct(product product, List<IFormFile>? Files);
		public Task<string> UpdateProduct(product product);
		public Task<string> DeleteProduct(product ProductId);

		public Task<bool> IsProductNameExist(string Name);



	}
}
