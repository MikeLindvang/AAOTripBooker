using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AAOTripBooker.Models
{
    public class DriverTrip
    {
        public int DriverId { get; set; }
        public Driver? Driver { get; set; }
        public int TripId { get; set; }
        public Trip? Trip { get; set; }
    }
}
