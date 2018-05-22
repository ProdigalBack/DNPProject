using System;
using System.Collections.Generic;
using System.Text;
using CinemaData.Models;

namespace CinemaData
{
    public interface IOrder
    {
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetOrdersById(int id);
        Order Get(int id);
        void Add(Order newOrder);
        void OrderTicket(int userId, int seatId);
        ShowingSeat GetSeat(int Id);
        User GetUser(int Id);
        string GetMovieName(int Id);
        int GetRow(int id);
        int GetColumn(int id);
        DateTime GetTime(int id);
    }
}
