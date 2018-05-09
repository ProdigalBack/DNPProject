using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIACinema.Controllers
{
    public class ContractController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
