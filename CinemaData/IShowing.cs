using CinemaData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaData
{
    public interface IShowing
    {
        IEnumerable<Showing> GetById(int id);

        Movie GetMovie(int Id);


    }
}
