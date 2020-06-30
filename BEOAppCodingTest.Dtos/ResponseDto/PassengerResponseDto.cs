using System;
using System.Collections.Generic;
using System.Text;

namespace BEOAppCodingTest.Dtos.ResponseDto
{
   public class PassengerResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Double Weight { get; set; }
        public int Status { get; set; }
        public int AppointmentId { get; set; }
    }
}
