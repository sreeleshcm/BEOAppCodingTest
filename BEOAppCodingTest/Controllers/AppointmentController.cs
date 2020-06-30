using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEOAppCodingTest.Dtos.RequestDto;
using BEOAppCodingTest.Dtos.ResponseDto;
using BEOAppCodingTest.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BEOAppCodingTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly ILogger<PassengerController> _logger;
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(ILogger<PassengerController> logger, IAppointmentService appointmentService)
        {
            _logger = logger;
            _appointmentService = appointmentService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<AppointmentResponseDto> Get()
        {
            _logger.LogInformation("Get all Appointment functionality initiated");
            return _appointmentService.GetAllAppointment();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public AppointmentResponseDto Get(int id)
        {
            _logger.LogInformation("Get Appointment functionality initiated");
            return _appointmentService.GetAppointmentById(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] AppointmentRequestDto value)
        {
            _logger.LogInformation("Add Appointment functionality initiated");
            _appointmentService.AddAppointment(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public void Put([FromBody] AppointmentRequestDto value)
        {
            _logger.LogInformation("Update Appointment functionality initiated");
            _appointmentService.UpdateAppointment(value);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
