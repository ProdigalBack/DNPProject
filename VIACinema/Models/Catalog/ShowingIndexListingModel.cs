using CinemaData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIACinema.Models.Catalog
{
    public class ShowingIndexListingModel
    {
        public int Id { get; set; }   
        public string Name { get; set; }          
        public int Runtime { get; set; }
        public string Director { get; set; }
        public string Actor { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Time { get; set; }
    }
}
