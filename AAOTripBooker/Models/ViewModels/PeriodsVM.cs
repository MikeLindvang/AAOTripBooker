using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAOTripBooker.Models.ViewModels
{
    public class PeriodsVM
    {
        public DriverPeriod DriverPeriod { get; set; }

        public Driver Driver { get; set; }
        public IEnumerable<SelectListItem>? DriverDropDown { get; set; }
    }
}
