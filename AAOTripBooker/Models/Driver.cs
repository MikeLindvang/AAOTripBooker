using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AAOTripBooker.Models
{
    
    public enum DriverStatus
    {
        Ledig, Passiv, Optaget
    }
    public enum DriverStartLocation
    {
        Odense
    }
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Navn")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Tlf. nr.")]
        [Required]
        public int Phone { get; set; }
        
        public string Email { get; set; }
        [DisplayName("Kørekort information")]
        [Required]
        public string DriversLicense { get; set; }
        
        [DisplayName("Status")]
        [Required]
        public DriverStatus DriverStatus { get; set; }
        [DisplayName("Startsted")]
        [Required]
        public DriverStartLocation DriverStartLocation { get; set; }
        
        public virtual ICollection<DriverPeriod>? DriverPeriods { get; set; }
        public virtual ICollection<DriverTrip>? DriverTrips { get; set; }
        
    }
}
