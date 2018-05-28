using VIACinema.Controllers;
using System.Threading.Tasks;
using CinemaData;
using Microsoft.AspNetCore.Mvc;
using VIACinema.Models.Login;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System;

namespace VIACinema.Controllers
{
    public class HomeController : Controller
    {
        private ILogin _login;
        private IRegister _register;

        public HomeController(ILogin login,IRegister register)
        {
            _login = login;
            _register = register;
        }

        public IActionResult Index()
        {
            return View();
        }
        

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel vm)
        {
            if (ModelState.IsValid)
            {
                try
               { 
                var result = _login.GetUser(vm.Email);

                if (result.Password.Equals(vm.Password))
                {
                    if (vm.Email.Equals("VIP"))
                    {
                        var identity = new ClaimsIdentity(new[]
             {
                 new Claim(ClaimTypes.Email,vm.Email),
                 new Claim(ClaimTypes.Role,"VIP"),
             }, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            principal);
                        return RedirectToAction("Index", "Catalog", new { id = result.Id });
                    }
                    else
                    {
                        var identity = new ClaimsIdentity(new[]
        {
                 new Claim(ClaimTypes.Email,vm.Email),

             }, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            principal);
                        return RedirectToAction("Index", "Catalog", new { id = result.Id });
                    }

                }
            }
                catch(InvalidOperationException)
                {
                    ModelState.AddModelError("", "Email doesn't exist");
                }

                ModelState.AddModelError("", "Password is incorrect");
                return View("Index");
            }
            return View("Index");
        }

        public IActionResult CreateAccount()
        {
            return View("Register");
        }
        [HttpPost]
        public async Task<IActionResult> Register(LoginModel vm)
        {
            if (ModelState.IsValid)
            {
                _register.Register(vm.Email, vm.Password);
            }
            return RedirectToAction("Index");
        }
            public IActionResult ErrorForbidden() => View();
        public IActionResult ErrorNotLoggedIn() => View();
    }
}
