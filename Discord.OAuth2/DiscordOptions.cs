using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Discord.OAuth2
{
    /// <inheritdoc />
    /// <summary> Configuration options for <see cref="T:Discord.OAuth2.DiscordHandler" />. </summary>
    public class DiscordOptions : OAuthOptions
    {
        /// <summary> Initializes a new <see cref="DiscordOptions"/>. </summary>
        public DiscordOptions()
        {
            CallbackPath = new PathString("/signin-discord");
            AuthorizationEndpoint = DiscordDefaults.AuthorizationEndpoint;
            TokenEndpoint = DiscordDefaults.TokenEndpoint;
            UserInformationEndpoint = DiscordDefaults.UserInformationEndpoint;
            Scope.Add("identify");

            ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id", ClaimValueTypes.UInteger64);
            ClaimActions.MapJsonKey(ClaimTypes.Name, "username", ClaimValueTypes.String);
            ClaimActions.MapJsonKey(ClaimTypes.Email, "email", ClaimValueTypes.Email);
            ClaimActions.MapJsonKey(DiscordClaimTypes.Discriminator, "discriminator", ClaimValueTypes.UInteger32);
            ClaimActions.MapJsonKey(DiscordClaimTypes.Avatar, "avatar", ClaimValueTypes.String);
            ClaimActions.MapJsonKey(DiscordClaimTypes.Verified, "verified", ClaimValueTypes.Boolean);
        }
        
        /// <summary> Gets or sets the Discord-assigned appId. </summary>
        public string AppId { get => ClientId; set => ClientId = value; }        
        /// <summary> Gets or sets the Discord-assigned app secret. </summary>
        public string AppSecret { get => ClientSecret; set => ClientSecret = value; }
    }
}
