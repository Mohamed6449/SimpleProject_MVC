using MCV_Empity.Data;
using MCV_Empity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MCV_Empity.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContect _context;
        public HomeController(AppDbContect context)
        {
            _context = context;
        }
        public async Task< IActionResult> Index()
        {
            var Categorys = await _context.Category.Include(I => I.product).Take(5).ToListAsync();


           
            return View(Categorys);
        
        }


    }

    
}
