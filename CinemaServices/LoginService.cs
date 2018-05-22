using CinemaData;
using CinemaData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaServices
{
    public class LoginService:ILogin
    {
        private CinemaContext _context;

        public LoginService(CinemaContext context)
        {
            _context = context;
        }

        public string GetName(int Id)
        {
            throw new NotImplementedException();
        }

        public string GetPassword(int Id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string email)
        {
            return _context.Users.First(u => u.Email == email);
        }
    }
}
