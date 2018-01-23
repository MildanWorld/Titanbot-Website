using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Discord.OAuth2;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;

namespace Titanbot.Web.LoginManagers
{
    // A lot of the functionality has been taken from the SignInManager, but
    // without the Identity hassle (Identity requires a persistent store by
    // default, but this is set up using no database).
    // https://github.com/aspnet/Identity/blob/dev/src/Identity/SignInManager.cs

    public class CookieSignInManager
    {
        private const string Scheme = CookieAuthenticationDefaults.AuthenticationScheme;
        private const string LoginProviderKey = "LoginProvider";

        public const string Provider = DiscordDefaults.AuthenticationScheme;

        private readonly IHttpContextAccessor _contextAccessor;

        public CookieSignInManager(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        private HttpContext _context;

        public HttpContext Context
        {
            get
            {
                var context = _context ?? _contextAccessor.HttpContext;
                if (context == null)
                    throw new InvalidOperationException("HttpContext must not be null.");
                return context;
            }
            set => _context = value;
        }
        

        public virtual AuthenticationProperties ConfigureExternalAuthenticationProperties(string redirectUrl)
        {
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            properties.Items[LoginProviderKey] = Provider;
            return properties;
        }
        
        public async Task<ExternalLoginInfo> GetExternalLoginInfoAsync()
        {
            var auth = await Context.AuthenticateAsync(Scheme);
            var items = auth?.Properties?.Items;
            if (auth?.Principal == null || items == null || !items.ContainsKey(LoginProviderKey))
            {
                return null;
            }

            var providerKey = auth.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var provider = items[LoginProviderKey];
            if (providerKey == null || provider == null)
            {
                return null;
            }

            return new ExternalLoginInfo(auth.Principal, provider, providerKey, provider)
            {
                AuthenticationTokens = auth.Properties.GetTokens()
            };
        }

        public async Task SignInAsync(ClaimsPrincipal userPrincipal)
        {
            await Context.SignInAsync(Scheme, userPrincipal, new AuthenticationProperties{ IsPersistent = true });
        }

        public async Task SignOutAsync()
        {
            await Context.SignOutAsync(Scheme);
        }

        public bool IsSignedIn(ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.Identities != null &&
                   principal.Identities.Any(i => i.AuthenticationType == Provider);
        }
    }
}
