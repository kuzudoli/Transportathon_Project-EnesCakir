using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Transportathon_Project_EnesCakir.Configurations;
using Transportathon_Project_EnesCakir.Entity;
using Transportathon_Project_EnesCakir.Extensions;
using Transportathon_Project_EnesCakir.Models.ViewModels;
using Transportathon_Project_EnesCakir.Utility;

namespace Transportathon_Project_EnesCakir.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly int _maxFailedAttempt;
        private readonly IEmailService _emailService;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _maxFailedAttempt = int.Parse(_configuration["IdentityOptions:FailedLoginMaxCount"]);
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel request)
        {
            if (!ModelState.IsValid)
                return View();

            var identityResult = await _userManager.CreateAsync(new()
            {
                UserName = request.Email.Split("@").First(),
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                PhoneNumber = request.Phone,
                BirthDate = request.BirthDate,
                IsCompany = request.IsCompany
            }, request.Password);

            if (!identityResult.Succeeded)
            {
                ModelState.AddModelIdentityError(identityResult.Errors);
                return View();
            }

            TempData["Succeed"] = "Hesabınız başarıyla oluşturuldu.";
            return View(nameof(SignIn));
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel request, string? returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl))
                returnUrl = Url.Action("Index", "Client")!;

            if (!ModelState.IsValid)
                return View();

            var hasUser = await _userManager.FindByEmailAsync(request.Email);
            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Email veya şifre yanlış!");
                return View();
            }

            var signInResult = await _signInManager.PasswordSignInAsync(hasUser, request.Password, request.RememberMe, true);

            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Çok fazla sayıda hatalı giriş yaptınız, 3 dakika sonra tekrar deneyiniz.");
                return View();
            }

            if (!signInResult.Succeeded)
            {
                var errorList = new List<IdentityError>() { new() { Description = "Email veya şifre yanlış!" } };

                var userAttemptCount = await _userManager.GetAccessFailedCountAsync(hasUser);
                if (userAttemptCount == _maxFailedAttempt - 1)
                    errorList.Add(new() { Description = "Tekrar hatalı giriş yaparsanız hesabınız geçici süreliğine kilitlenecektir." });
                
                ModelState.AddModelIdentityError(errorList);
                return View();
            }

            return Redirect(returnUrl);
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                TempData["Info"] = "Şifre sıfırlama bağlantısı, e-posta adresine gönderildi.";
                return RedirectToAction(nameof(ForgotPassword));
            }

            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            string passwordResetLink = Url.Action("ResetPassword", "Auth", new { userId = user.Id, token = passwordResetToken }, HttpContext.Request.Scheme)!;

            await _emailService.SendResetPasswordEmailAsync(passwordResetLink, request.Email);

            TempData["Info"] = "Şifre sıfırlama bağlantısı, e-posta adresine gönderildi.";
            return RedirectToAction(nameof(ForgotPassword));
        }

        public IActionResult ResetPassword(string userId, string token)
        {
            TempData["userId"] = userId;
            TempData["token"] = token;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel request)
        {
            var userId = TempData["userId"];
            var token = TempData["token"];

            if (userId == null || token == null)
                throw new Exception("Bir hata oluştu. Daha sonra tekrar deneyiniz.");

            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Bir hata oluştu. Daha sonra tekrar deneyiniz.");
                return View();
            }

            var result = await _userManager.ResetPasswordAsync(user, token.ToString(), request.Password);

            return RedirectToAction(nameof(SignIn));
        }
    }
}