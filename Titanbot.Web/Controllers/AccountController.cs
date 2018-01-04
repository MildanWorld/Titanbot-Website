using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord.OAuth2;
using Microsoft.AspNetCore.Mvc;

namespace Titanbot.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login()
        {
            // Challenge here
            var redirectUrl = Url.Action(nameof(LoginCallback), "Account", new { returnUrl });

            

            return View();
        }

        public IActionResult LoginCallback(string returnUrl = null, string remoteError = null)
        {


            return View();
        }
    }
}
