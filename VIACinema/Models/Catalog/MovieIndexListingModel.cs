using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIACinema.Models.Catalog
{
    public class MovieIndexListingModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
