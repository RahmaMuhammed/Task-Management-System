using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Task_Management_System.Models.Entites;
using Task_Management_System.ViewModels;

namespace Task_Management_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager) 
        {
            _userManager = userManager;
        }
        // Register
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    FName = model.FName,
                    Email = model.Email,
                    LName = model.LName,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    UserName = model.Email.Split('@')[0],
                    DOB = model.DOB,
                    IsAgree = model.IsAgree
                    
                };
                var result = await _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
                return View(model);
        }
        // Login
        // Logout
        // Forget Password
        // Reset Password 
    }
}
