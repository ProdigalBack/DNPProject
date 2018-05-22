using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CinemaData;
using CinemaData.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaServices
{
    public class SeatService : IShowingSeat
    {
        private CinemaContext _context;

        public SeatService(CinemaContext context)
        {
            _context = context;
        }
        public IEnumerable<ShowingSeat> GetSeatsById(int Id)
        {
            return _context.ShowingSeats
                .Include(s => s.Seat)
                .Include(s => s.Showing)
                .Where(s => s.Showing.Id==Id);
        }

        public Seat GetSeat(int Row,int Column)
        {
            throw new NotImplementedException();
        }

        public Showing GetShowing(int Id)
        {
            return GetShowingSeat(Id).Showing;
        }

        public IEnumerable<ShowingSeat> GetAll()
        {
            return _context.ShowingSeats;
        }

        public ShowingSeat GetShowingSeat(int Id)
        {
            return _context.ShowingSeats
                .Include(s => s.Seat)
                .Include(s => s.Showing)
                .First(s => s.Id == Id); 
        }
    }
}
