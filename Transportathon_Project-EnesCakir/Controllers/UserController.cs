using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Transportathon_Project_EnesCakir.Entity;
using Transportathon_Project_EnesCakir.Extensions;
using Transportathon_Project_EnesCakir.Models.ViewModels;

namespace Transportathon_Project_EnesCakir.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SignOut(string returnUrl)
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(EditUserViewModel request)
        {
            if (!ModelState.IsValid)
                return View();

            var user = await _userManager.FindByNameAsync(User.Identity!.Name);
            if (user == null)
                throw new Exception("Bir hata oluştu!");

            user.Name = request.Name;
            user.Surname = request.Surname;
            user.BirthDate = request.BirthDate;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                ModelState.AddModelIdentityError(result.Errors);
                return View();
            }

            await _userManager.UpdateSecurityStampAsync(user);
            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(user, false);

            TempData["Succeed"] = "Profiliniz başarıyla güncellendi.";

            return RedirectToAction("EditProfile", "Client");
        }
    }
}