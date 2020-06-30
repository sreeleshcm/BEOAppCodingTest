using System;
using System.Collections.Generic;
using System.Text;

namespace BEOAppCodingTest.Dtos.ResponseDto
{
    public class AppointmentResponseDto
    {
        public int Id { get; set; }
        public DateTime ReleaseDate { get; set; }

        public bool Confirmed { get; set; }

        public int Capacity { get; set; }
        public double TotalWeight { get; set; }
    }
}
