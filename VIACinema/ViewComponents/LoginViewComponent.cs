using CinemaData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIACinema.ViewComponents
{
    public class LoginViewComponent:ViewComponent
    {
        private ILogin _login;
        public LoginViewComponent(ILogin login)
        {
            _login = login;
        }
    }
}
