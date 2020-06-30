using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEOAppCodingTest.Dtos.RequestDto
{
    public class PassengerRequestDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        public Double Weight { get; set; }
        public int AppointmentId { get; set; }
    }
}
