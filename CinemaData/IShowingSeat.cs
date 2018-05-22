using CinemaData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaData
{
    public interface IShowingSeat
    {
        IEnumerable<ShowingSeat> GetSeatsById(int Id);
        IEnumerable<ShowingSeat> GetAll();
        Seat GetSeat(int Row,int Column);
        ShowingSeat GetShowingSeat(int Id);
        Showing GetShowing(int Id);
    }
}
