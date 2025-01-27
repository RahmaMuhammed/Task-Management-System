using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Task_Management_System.Models.Entites;
using Task_Management_System.ViewModels;

namespace Task_Management_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var result = await _userManager.CheckPasswordAsync(user, model.Password);
                    if (result)
                    {
                        var loginResult = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                        if (loginResult.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Password is Incorrect");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email is Not Exists");
                }
            }
                return View(model);
        }
        // Logout
        // Forget Password
        // Reset Password 
    }
}
