using MCV_Empity.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using MCV_Empity.ViewModels.Categories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MCV_Empity.Models.Identity;
using MCV_Empity.ViewModels.Identity.Roles;
using MCV_Empity.ViewModels.Identity.Users;

namespace MCV_Empity.Data

{
	public class AppDbContect : IdentityDbContext
	{
		public AppDbContect()
		{

		}
		public AppDbContect(DbContextOptions<AppDbContect>options) : base(options) { 
		}

		public DbSet<product>Products { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<ProductImages> ProductImages { get; set; }
		public DbSet<User> User { get; set; }

		public DbSet<Claim> claims { get; set; }

		public DbSet<MCV_Empity.ViewModels.Identity.Users.GetUserByIdViewModel> GetUserByIdViewModel { get; set; } = default!;

	}
}
