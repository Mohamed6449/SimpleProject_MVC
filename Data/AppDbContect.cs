using MCV_Empity.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using MCV_Empity.ViewModels.Categories;

namespace MCV_Empity.Data

{
	public class AppDbContect : DbContext
	{
		public AppDbContect()
		{

		}
		public AppDbContect(DbContextOptions<AppDbContect>options) : base(options) { 
		}

		public DbSet<product>Products { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<ProductImages> ProductImages { get; set; }
	    public DbSet<MCV_Empity.ViewModels.Categories.GetCategoriesListViewModel> GetCategoriesListViewModel { get; set; } = default!;
	    public DbSet<MCV_Empity.ViewModels.Categories.GetCategoryByIdViewModel> GetCategoryByIdViewModel { get; set; } = default!;

	}
}
