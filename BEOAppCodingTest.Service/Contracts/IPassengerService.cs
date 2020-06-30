using BEOAppCodingTest.Dtos.RequestDto;
using BEOAppCodingTest.Dtos.ResponseDto;
using BEOAppCodingTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEOAppCodingTest.Service.Contracts
{
    public interface IPassengerService
    {
        void AddPassenger(PassengerRequestDto entity);
        void UpdatePassenger(PassengerRequestDto entity);
        List<PassengerResponseDto> GetAllPassenger();
        PassengerResponseDto GetPassenegerById(int id);
        void UpdateStatus(UpdateStatusDto inputData);
        double GetTotalWeight(int id);
    }
}
