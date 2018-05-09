using CinemaData;
using CinemaData.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;

namespace CinemaServices
{
    public class MovieService : IMovie
    {
        private CinemaContext _context;

        public MovieService(CinemaContext context)
        {
            _context = context;
        }
        public string GetActor(int id)
        {
            if (_context.Movies.Any(movie => movie.Id == id))
            {
                return _context.Movies.FirstOrDefault(movie => movie.Id == id).Actor;
            }
            else
                return "";
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies;
        }

        public Movie getById(int  id)
        {
            return GetAll().FirstOrDefault(movie => movie.Id == id);
        }

        public string GetDescription(int  id)
        {
            if (_context.Movies.Any(movie => movie.Id == id))
            {
                return _context.Movies.FirstOrDefault(movie => movie.Id == id).Description;
            }
            else
                return "";
        }

        public string GetDirector(int id)
        {
            if (_context.Movies.Any(movie => movie.Id == id))
            {
                return _context.Movies.FirstOrDefault(movie => movie.Id == id).Director;
            }
            else
                return "";
        }

        public string GetImgUrl(int id)
        {
            if (_context.Movies.Any(movie => movie.Id == id))
            {
                return _context.Movies.FirstOrDefault(movie => movie.Id == id).ImageUrl;
            }
            else
                return "";
        }

        public string getName(int id)
        {
             if (_context.Movies.Any(movie => movie.Id == id))
            {
                return _context.Movies.FirstOrDefault(movie => movie.Id == id).Name;
            }
            else
                return "";
        }

        public int GetRuntime(int id)
        {
            if (_context.Movies.Any(movie => movie.Id == id))
            {
                return _context.Movies.FirstOrDefault(movie => movie.Id == id).Runtime;
            }
            else
                return 0;
        }
    }
}
