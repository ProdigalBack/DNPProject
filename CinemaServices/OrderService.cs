using CinemaData;
using CinemaData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaServices
{
    public class OrderService : IOrder
    {
        private CinemaContext _context;

        public OrderService(CinemaContext context)
        {
            _context = context;
        }

        public void Add(Order newOrder)
        {
            _context.Add(newOrder);
            _context.SaveChanges();
        }

        public Order Get(int id)
        {
           return GetAll().First(o => o.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Order
                 .Include(o => o.ShowingSeat)
                 .ThenInclude(showingSeat=>showingSeat.Showing)          
                 .ThenInclude(showing=>showing.Movie)
                .Include(o => o.User)
                .Include(o => o.ShowingSeat)
                .ThenInclude(showingSeat => showingSeat.Seat);
            

        }

        public int GetColumn(int id)
        {
            throw new NotImplementedException();
        }

        public string GetMovieName(int id)
        {
            return GetAll().First(o => o.Id == id).ShowingSeat.Showing.Movie.Name;
        }

        public IEnumerable<Order> GetOrdersById(int id)
        {
            return GetAll()
                .Where(o => o.User.Id == id);
        }

        public int GetRow(int id)
        {
            throw new NotImplementedException();
        }

        public ShowingSeat GetSeat(int Id)
        {
            return GetAll()
                .First(o => o.ShowingSeat.Id == Id).ShowingSeat;
                
        }

        public DateTime GetTime(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int Id)
        {
            return _context.Order
                 .Include(o => o.ShowingSeat)
                 .Include(o => o.User)
                 .First(o => o.User.Id == Id).User;
        }

        public void OrderTicket(int userId, int seatId)
        {
            var showingSeat = _context.ShowingSeats
                 .Include(s => s.Seat)
                 .Include(s => s.Showing)
                 .First(s => s.Id == seatId);
            _context.Update(showingSeat);

            showingSeat.Status = "Ordered";

            var user = _context.Users.First(u => u.Id == userId);

            var order = new Order
            {
                User = user,
                ShowingSeat = showingSeat
            };

            _context.Add(order);
            _context.SaveChanges();
                
        }
    }
}
