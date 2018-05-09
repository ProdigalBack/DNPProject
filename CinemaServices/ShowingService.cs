using CinemaData;
using CinemaData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaServices
{
    public class ShowingService:IShowing
    {
        private CinemaContext _context;

        public ShowingService(CinemaContext context)
        {
            _context = context;
        }

      
   
        public IEnumerable<Showing> GetById(int id)
        {
            return _context.Showings
                .Include(s=>s.Movie)
                .Where(showing => showing.Movie.Id == id);
        }

        public Movie GetMovie(int Id)
        {
            return _context.Showings
                .Include(s => s.Movie)
                .First(s => s.Id == Id).Movie;
        }
    }
}
