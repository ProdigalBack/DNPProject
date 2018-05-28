using CinemaData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaData
{
    public interface IRegister
    {
        void Register(string Email,string Password);
        
    }
}
