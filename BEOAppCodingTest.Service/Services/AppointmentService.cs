using AutoMapper;
using BEOAppCodingTest.DataAccess;
using BEOAppCodingTest.Dtos.RequestDto;
using BEOAppCodingTest.Dtos.ResponseDto;
using BEOAppCodingTest.Models;
using BEOAppCodingTest.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEOAppCodingTest.Service.Services
{
    public class AppointmentService: IAppointmentService
    {
        private readonly IUnitOfWork _untofwork;
        private readonly IRepository<Appointment> _repository;
        private readonly IMapper _mapper;
        private readonly IPassengerService _passengerService;
        public AppointmentService(IUnitOfWork unitofwork, IRepository<Appointment> repository, IMapper mapper, IPassengerService passengerService)
        {
            _untofwork = unitofwork;
            _repository = repository;
            _mapper = mapper;
            _passengerService = passengerService;
        }
        public void AddAppointment(AppointmentRequestDto entity)
        {
            Appointment passengerModel = _mapper.Map<Appointment>(entity);
            _repository.Add(passengerModel);
            _untofwork.Commit();
        }
        public void UpdateAppointment(AppointmentRequestDto entity)
        {
            Appointment passengerModel = _mapper.Map<Appointment>(entity);
            _repository.Update(passengerModel);
            _untofwork.Commit();
        }
        public List<AppointmentResponseDto> GetAllAppointment()
        {
            var returnData = _mapper.Map<List<AppointmentResponseDto>>(_repository.Get());
            foreach (var data in returnData)
            {
                data.TotalWeight = _passengerService.GetTotalWeight(data.Id);
            }
            return returnData;
        }

        public AppointmentResponseDto GetAppointmentById(int id)
        {
            return _mapper.Map<AppointmentResponseDto>(_repository.Get(x => x.Id == id).FirstOrDefault());
        }
    }
}
