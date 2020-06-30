using AutoMapper;
using BEOAppCodingTest.DataAccess;
using BEOAppCodingTest.Dtos.RequestDto;
using BEOAppCodingTest.Dtos.ResponseDto;
using BEOAppCodingTest.Models;
using BEOAppCodingTest.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BEOAppCodingTest.Service
{
    public class PassengerService: IPassengerService
    {
        private readonly IUnitOfWork _untofwork;
        private readonly IRepository<Passenger> _repository;
        private readonly IMapper _mapper;
       public PassengerService(IUnitOfWork unitofwork, IRepository<Passenger> repository, IMapper mapper)
        {
            _untofwork = unitofwork;
            _repository = repository;
            _mapper = mapper;
        }
        public void AddPassenger(PassengerRequestDto entity)
        {
            Passenger passengerModel = _mapper.Map<Passenger>(entity);
            passengerModel.Status = 2;
            _repository.Add(passengerModel);
            _untofwork.Commit();
        }

        public void UpdatePassenger(PassengerRequestDto entity)
        {
            Passenger passengerModel = _mapper.Map<Passenger>(entity);
            _repository.Update(passengerModel);
            _untofwork.Commit();
        }
        public void UpdateStatus(UpdateStatusDto inputData)
        {
            Passenger passengerModel = _mapper.Map<Passenger>(_repository.Get(x=>x.AppointmentId==inputData.AppointmentId).FirstOrDefault());
            if (inputData.Comfirmed)
            {
                passengerModel.Status = 3;
            }
            else
            {
                passengerModel.Status = 1;
            }
            _repository.Update(passengerModel);
            _untofwork.Commit();
        }
        
        public List<PassengerResponseDto> GetAllPassenger()
        {
            return _mapper.Map<List<PassengerResponseDto>>(_repository.Get());
        }

        public PassengerResponseDto GetPassenegerById(int id)
        {
            return _mapper.Map<PassengerResponseDto>(_repository.Get(x=>x.Id==id).FirstOrDefault());
        }
        public double GetTotalWeight(int id)
        {
            return _repository.Get(x => x.Id == id).Sum(x=>x.Weight);
        }
    }
}
