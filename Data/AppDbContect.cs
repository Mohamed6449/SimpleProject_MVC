using MCV_Empity.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

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

	}
}
