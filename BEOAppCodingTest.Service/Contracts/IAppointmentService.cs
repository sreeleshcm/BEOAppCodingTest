using BEOAppCodingTest.Dtos.RequestDto;
using BEOAppCodingTest.Dtos.ResponseDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEOAppCodingTest.Service.Contracts
{
    public interface IAppointmentService
    {
        void AddAppointment(AppointmentRequestDto entity);
        void UpdateAppointment(AppointmentRequestDto entity);
        List<AppointmentResponseDto> GetAllAppointment();
        AppointmentResponseDto GetAppointmentById(int id);
    }
}
