using MCV_Empity.Models;
using Microsoft.AspNetCore.Mvc;

namespace MCV_Empity.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var pro = new product() { Name = "ahmed", Id = 3 };
            return View(pro);
        }

        public IActionResult Details([FromRoute(Name ="id")] int nu)
        {
            var pro = new product() { Name = "ahmed", Id = 3 };
            return View(pro);
        }

    }
}
