using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIACinema.Controllers
{
    public class VIPController : Controller
    {
       [Authorize(Policy="MustBeVIP")]
        public IActionResult VIP()
        {
            return View();
        }
    }
}
