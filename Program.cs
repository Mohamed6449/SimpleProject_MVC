using MCV_Empity.Data;
using MCV_Empity.Services.Implementations;
using MCV_Empity.Services.InterFaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContect>(S => S.UseSqlServer(builder.Configuration["ConnectionStrings:dbconntext"]));
var varia = builder.Configuration["key"];

builder.Services.AddSingleton<IProductService, ProductService>();

//builder.Services.AddScoped<IProductService, ProductService>();

//builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddTransient<IFileServiece,FileServices>();

builder.Services.AddControllersWithViews();


var app = builder.Build();

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(name: "default"
    , pattern: "{Controller=Home}/{Action=Index}/{Id?}");
//app.MapGet("/", () => varia);



app.Run();
