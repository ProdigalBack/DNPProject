using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIACinema.Models.OrderHistory
{
    public class OrderIndexModel
    {
        public IEnumerable<OrderIndexListingModel> OrderHistory { get; set; }
    }
}
