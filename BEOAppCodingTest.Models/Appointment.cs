using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEOAppCodingTest.Models
{
    [Table("appointment")]
    public class Appointment: BaseEntity
    {
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public bool Confirmed { get; set; }

        public int Capacity { get; set; }

        [ForeignKey("AppointmentId")]
        public ICollection<Passenger> Passenger { get; set; }
    }
}
