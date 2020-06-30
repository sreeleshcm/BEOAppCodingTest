using System;
using System.Collections.Generic;
using System.Text;

namespace BEOAppCodingTest.Dtos.RequestDto
{
    public class UpdateStatusDto
    {
        public int AppointmentId { get; set; }
        public bool Comfirmed { get; set; }
    }
}
