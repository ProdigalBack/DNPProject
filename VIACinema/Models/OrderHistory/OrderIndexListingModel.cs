using CinemaData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIACinema.Models.OrderHistory
{
    public class OrderIndexListingModel
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }       
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
