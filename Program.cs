using MCV_Empity.Data;
using MCV_Empity.DependencyInjections;
using MCV_Empity.Repository.implementation;
using MCV_Empity.Repository.Interface;
using MCV_Empity.Resources;
using MCV_Empity.Services.Implementations;
using MCV_Empity.Services.InterFaces;
using MCV_Empity.SharedRepository;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceDependencyInjection().AddRepositryDependencyInjection()
    .AddLocalizationDependencyInjection()
	.AddGeneralRegistrationDependencyInjection(builder.Configuration).AddIdentityDependencyInjection();


builder.Services.AddControllersWithViews();

#region Localization

#endregion

var app = builder.Build();

app.AddApplicationBuillderDependencyInjection(app.Services);

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.UseEndpoints(endpoints =>
{
	_ = endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");
});



app.Run();
