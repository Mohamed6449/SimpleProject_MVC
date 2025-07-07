using MCV_Empity.ViewModels.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MCV_Empity.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        
        public AccountController(UserManager<IdentityUser> userManager , SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
                       await _signInManager.SignInAsync(NewUser, isPersistent:false);
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


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index","Home");
        }  
    }
}
