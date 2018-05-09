using System;
using System.Collections.Generic;
using System.Text;
using CinemaData.Models;

namespace CinemaData
{
    public interface IOrder
    {
        IEnumerable<Order> GetAll();
        Order Get(int id);
        void Add(Order newOrder);
        void OrderTicket(int userId, int seatId);
        string GetSeat(int id);
    }
}
