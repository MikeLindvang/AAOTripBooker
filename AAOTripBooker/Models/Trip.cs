using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AAOTripBooker.Models
{
    public enum Traffic
    {
        BO_ARB, BY, REGIONAL, FJERN, MOD_FERIE, UDPR_FERIE, SOMMERLAND
    }
    public enum Status
    {
        Aktiv, Inaktiv, Passiv
    }
    public enum StartLocation
    { 
        Odense 
    }
    public class Trip
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Startdato")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Slutdato")]
        public DateTime EndDate { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DisplayName("Starttid")]
        public DateTime StartTime { get; set; }
        [DisplayName("Varighed")]
        public int Duration { get; set; }
        [DisplayName("Slå til for hele dage")]
        public bool Days { get; set; }
        [DisplayName("Trafik")]
        public Traffic Traffic { get; set; }
        [DisplayName("Afdeling")]
        public string Department { get; set; }
        public Status Status { get; set; }
        [DisplayName("Startsted")]
        public StartLocation StartLocation { get; set; }
        [DisplayName("Hastetur")]
        public bool Urgent { get; set; }
        [DisplayName("Kontakt")]
        public string Contact { get; set; }
        [DisplayName("Beskrivelse")]
        public string Description { get; set; }

        public virtual ICollection<DriverTrip>? DriverTrips { get; set; }
    }
}
