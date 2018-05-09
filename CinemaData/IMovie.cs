using CinemaData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaData
{
   public interface IMovie
    {
        IEnumerable<Movie> GetAll();
        Movie getById(int Id);
        string getName(int Id);
        int GetRuntime(int Id);
        string GetDirector(int  Id);
        string GetActor(int  Id);
        string GetDescription(int  Id);
        string GetImgUrl(int Id);
    }
}
