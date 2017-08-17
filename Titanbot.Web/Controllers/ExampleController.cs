using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Titanbot.Web.ViewModels;
using Titanbot.Web._HardcodedValues;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Titanbot.Web.Controllers
{
    public class ExampleController : Controller
    {
        private readonly HardcodedCommands _hardcodedCommands;

        public ExampleController(HardcodedCommands hardcodedCommands)
        {
            _hardcodedCommands = hardcodedCommands;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = new AllCommands
            {
                Commands = _hardcodedCommands.Commands
            };

            return View(model);
        }
    }
}
