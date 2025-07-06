using MCV_Empity.ViewModels.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MCV_Empity.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        
        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
               var user=await _userManager.FindByEmailAsync(register.Email);

                if (user == null)
                {
                    var NewUser = new IdentityUser()
                    {
                        Email = register.Email,
                        UserName = register.Email
                    };
                    var result = await _userManager.CreateAsync(NewUser,register.Password);

                    if (result.Succeeded)
                    {
                       return RedirectToAction("Index", "Home");
                    }
                    foreach(var error in result.Errors)
                    {

                         ModelState.AddModelError("",error.Description);
                    }
                    return View(register);
                }
                ModelState.AddModelError("","User is already Exist");

                return View(register);
                

            }
            return View(register);
        }
    }
}
