using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace LibApp.Controllers
{
    [Authorize(Roles = "Owner")]
    public class RentalsController : Controller
    {
        public IActionResult New()
        {
            return View();
        }
    }
}
