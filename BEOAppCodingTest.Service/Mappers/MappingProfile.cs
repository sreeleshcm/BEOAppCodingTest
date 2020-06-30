using AutoMapper;
using BEOAppCodingTest.Dtos.RequestDto;
using BEOAppCodingTest.Dtos.ResponseDto;
using BEOAppCodingTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEOAppCodingTest.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Passenger, PassengerRequestDto>();
            CreateMap<PassengerRequestDto, Passenger>();
            CreateMap<Appointment, AppointmentRequestDto>();
            CreateMap<AppointmentRequestDto, Appointment>();
            CreateMap<Passenger, PassengerResponseDto>();
            CreateMap<PassengerResponseDto, Passenger>();
            CreateMap<Appointment, AppointmentResponseDto>();
            CreateMap<AppointmentResponseDto, Appointment>();

        }
    }
}
