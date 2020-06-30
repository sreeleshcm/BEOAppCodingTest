using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEOAppCodingTest.Dtos.RequestDto
{
    public class AppointmentRequestDto
    {
        public int Id { get; set; }
        public DateTime ReleaseDate { get; set; }

        public bool Confirmed { get; set; }

        public int Capacity { get; set; }
    }
}
