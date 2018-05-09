using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIACinema.Models.Catalog
{
    public class ShowingSeatIndexModel
    {
        public IEnumerable<ShowingSeatIndexListingModel> ShowingSeats { get; set; }
    }
}
