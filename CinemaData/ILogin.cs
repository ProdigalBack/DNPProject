using CinemaData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaData
{
    public interface ILogin
    {
        string GetName(int Id);
        string GetPassword(int Id);

        User GetUser(string email);
    }
}
