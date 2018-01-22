using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Discord.OAuth2;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Titanbot.Web.Controllers
{
    public class AccountController : Controller
    {
        private const string LoginProviderKey = "LoginProvider";
        private const string Provider = "Discord";

        private readonly IHttpContextAccessor _contextAccessor;

        public AccountController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login()
        {
            var redirectUrl = Url.Action(nameof(LoginCallback), "Account", new { returnUrl = "Home" });
            var properties = new AuthenticationProperties
            {
                RedirectUri = redirectUrl
            };
            properties.Items[LoginProviderKey] = Provider;

            return Challenge(properties, Provider);
        }

        public async Task<IActionResult> LoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                ErrorMessage = $"Error from Discord: {remoteError}";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var info = await GetExternalLoginInfoAsync();
            if (info == null)
                return RedirectToAction(nameof(Login));
            


            return View();
        }

        // Stolen from the SignInManager, but without all the Identity hassle
        // https://github.com/aspnet/Identity/blob/dev/src/Identity/SignInManager.cs
        private async Task<ExternalLoginInfo> GetExternalLoginInfoAsync()
        {
            var auth = await _contextAccessor.HttpContext.AuthenticateAsync(IdentityConstants.ExternalScheme);
            var items = auth?.Properties?.Items;
            if (auth?.Principal == null || items == null || !items.ContainsKey(LoginProviderKey))
            {
                return null;
            }

            var providerKey = auth.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var provider = items[LoginProviderKey] as string;
            if (providerKey == null || provider == null)
            {
                return null;
            }

            return new ExternalLoginInfo(auth.Principal, provider, providerKey, provider)
            {
                AuthenticationTokens = auth.Properties.GetTokens()
            };
        }
    }
}
