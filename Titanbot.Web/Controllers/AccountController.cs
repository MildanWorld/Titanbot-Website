using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Titanbot.Web.LoginManagers;

namespace Titanbot.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly CookieSignInManager _signInManager;
        
        

        public AccountController(CookieSignInManager signInManager)
        {
            _signInManager = signInManager;
        }

        [TempData]
        public string ErrorMessage { get; set; }
        
        public IActionResult Login()
        {
            var redirectUrl = Url.Action(nameof(LoginCallback), "Account", new { returnUrl = "Home" });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(redirectUrl);
            return Challenge(properties, CookieSignInManager.Provider);
        }

        public async Task<IActionResult> LoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                ErrorMessage = $"Error from Discord: {remoteError}";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            await _signInManager.SignInAsync(info.Principal);


            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
