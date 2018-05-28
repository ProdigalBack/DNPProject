using CinemaData;
using CinemaData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaServices
{
    public class RegisterService:IRegister
    {
        private CinemaContext _context;

        public RegisterService(CinemaContext context)
        {
            _context = context;
        }

        public void Register(string Email, string Password)
        {
            var newUser = new User
            {
                Email = Email,
                Password=Password
            };
            _context.Add(newUser);
            _context.SaveChanges();
        }
    }
}
