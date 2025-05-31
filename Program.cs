using MCV_Empity.Data;
using MCV_Empity.Services.Implementations;
using MCV_Empity.Services.InterFaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContect>(S => S.UseSqlServer(builder.Configuration["ConnectionStrings:dbconntext"]));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddTransient<ICategoryServices, CategoryServices>();


builder.Services.AddTransient<IFileServiece,FileServices>();

builder.Services.AddControllersWithViews();


var app = builder.Build();

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();


app.UseEndpoints(endpoints =>
{
	_ = endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.UseAuthentication();

app.UseAuthorization();

app.Run();
