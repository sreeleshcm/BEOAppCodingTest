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
    public class PassengerController : ControllerBase
    {
        private readonly ILogger<PassengerController> _logger;
        private readonly IPassengerService _passengerService;

        public PassengerController(ILogger<PassengerController> logger, IPassengerService passengerService)
        {
            _logger = logger;
            _passengerService = passengerService;
        }
        // GET: api/<PassengerController>
        [HttpGet]
        public IEnumerable<PassengerResponseDto> Get()
        {
            _logger.LogInformation("Get all  Passenger functionality initiated");
            return _passengerService.GetAllPassenger();
        }

        // GET api/<PassengerController>/5
        [HttpGet("{id}")]
        public PassengerResponseDto Get(int id)
        {
            _logger.LogInformation("Get Passenger functionality initiated");
            return _passengerService.GetPassenegerById(id);
        }

        // POST api/<PassengerController>
        [HttpPost]
        public void Post([FromBody] PassengerRequestDto value)
        {
            _logger.LogInformation("Add Passenger functionality initiated");
            _passengerService.AddPassenger(value);
        }

        // PUT api/<PassengerController>/5
        [HttpPut]
        public void Put([FromBody] PassengerRequestDto value)
        {
            _logger.LogInformation("Passenger update functionality initiated");
            _passengerService.UpdatePassenger(value);
        }

        // POST api/<PassengerController>
        [HttpPost]
        [Route("UpdateStatus")]
        public void UpdateStatus([FromBody] UpdateStatusDto value)
        {
            _logger.LogInformation("Update Passenger status functionality initiated");
            _passengerService.UpdateStatus(value);
        }

        // DELETE api/<PassengerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
