using System;
using System.Security.Claims;
using Discord.OAuth2;

namespace Titanbot.Web.LoginManagers
{
    // A lot of the functionality has been taken from the UserManager, but
    // without the Identity hassle (Identity requires a persistent store by
    // default, but this is set up using no database).
    // https://github.com/aspnet/Identity/blob/dev/src/Core/UserManager.cs
    public class CookieUserManager
    {


        public string GetUserName(ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            var name = principal.FindFirstValue(ClaimTypes.Name);
            var discriminator = principal.FindFirstValue(DiscordClaimTypes.Discriminator);
            return $"{name}#{discriminator}";
        }


    }
}
