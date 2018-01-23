using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Titanbot.Web.Models.LoginModels
{
    public static class DiscordClaimTypes
    {
        public static string Discriminator => "urn:discord:discriminator";
        public static string Avatar => "urn:discrod:avatar";
        public static string Verified => "urn:discord:verified";
    }
}
