using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AAOTripBooker.Models
{
    public class DriverPeriod
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Startdato")]
        [Required]
        public DateTime DriverStartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Slutdato")]
        [Required]
        public DateTime DriverEndDate { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DisplayName("Starttid")]
        [Required]
        public DateTime DriverStartTime { get; set; }
        
        public int DriverId { get; set; }
        public Driver? Driver { get; set; }

    }
}
