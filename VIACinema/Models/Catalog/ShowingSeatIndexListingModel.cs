using CinemaData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIACinema.Models.Catalog
{
    public class ShowingSeatIndexListingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Showing Showing { get; set; }
        public Seat Seat { get; set; }
        public string Status { get; set; }
    }
}
