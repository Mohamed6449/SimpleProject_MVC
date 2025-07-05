using MCV_Empity.Data;
using MCV_Empity.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace MCV_Empity.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContect _context;

        private int UserId = 1;

        private string UserName = "Mohamed";
        public HomeController(AppDbContect context)
        {
            _context = context;
        }

        public async Task< IActionResult> Index()
        {
            //         CookieOptions cookieOptions= new CookieOptions();
            //         cookieOptions.Expires = DateTime.UtcNow.AddSeconds(20);
            //Response.Cookies.Append("UserId", UserId.ToString());
            //         Response.Cookies.Append("UserName", UserName);

           // // هنا عشان نحط اوجيكت بس لازم يتحول ل جيسون 
           // HttpContext.Session.Set("Key",JsonSerializer.SerializeToUtf8Bytes(Product));

           // // هنا للاخذ واعادة تحويل 
           //var result= HttpContext.Session.Get("Ker");
           // product = JsonSerializer.Deserialize<product>(result);

            //HttpContext.Session.SetInt32("UserId",3);
            //HttpContext.Session.SetString("UserName", "mohamed");
            var Categorys = await _context.Category.Include(I => I.product).Take(5).ToListAsync();

            TempData["UserId"] = 1;
            
            TempData["UserName"] = "Mohamed";

           
            return View(Categorys);
        
        }

        public IActionResult Privacy()
        {

           var d= TempData["UserId"];

			return View();
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

    }

    
}
