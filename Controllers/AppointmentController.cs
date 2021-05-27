using Itenso.TimePeriod;
using MedicalAppointmentBooking.Models;
using MedicalAppointmentBooking.Services;
using Microsoft.VisualBasic;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedicalAppointmentBooking.Controllers
{
    public class AppointmentController : ApiController
    {
        private readonly IDataService _dataService;

        public AppointmentController(IDataService dataService)
        {
            _dataService = dataService;
        }
        private DateTime DateAdd(DateInterval interval, double number, DateTime dateValue)
        {
            DateTime dtm = dateValue;
            // DateInterval.DayOfYear and DateInterval.Weekday appear the same
            // as DateInterval.Day.
            // Looking at http://msdn.microsoft.com/en-us/library/hcxe65wz(v=vs.71).aspx 
            // also seems to indicate they are the same as DateInterval.Day.
            switch (interval)
            {
                
                case DateInterval.Minute:
                    dtm = dateValue.AddMinutes(number);
                    break;
                
            }
            return dtm;
        }

        public List<Appointment> GetAppointments(Appointment item)
        {
            DateInterval minute = DateInterval.Minute;
            var startTime = Convert.ToDateTime("08:00");
            var endTime = Convert.ToDateTime("18:00");
            var interval = 15;
            var desiredLength = 15;

            var from = startTime;
            var to = DateAdd(minute, desiredLength, startTime);                  
            
            var lstAppointment = _dataService.GetAllAppointment().Select(a => new Appointment {
                StartDate = a.StartDate = DateAdd(minute, interval, from),
                EndDate = a.EndDate = DateAdd(minute, interval, to)
            }).Where(p=> DateAdd(minute, interval, to) <= endTime);

            return lstAppointment.ToList();
        }
        public bool ChecktAvailable(Appointment item)
        {
            DateInterval minute = DateInterval.Minute;
            var interval = 15;
            var desiredLength = 15;

            var lstAppointment = GetAppointments(item);
            return !lstAppointment.Any(p => p.StartDate < item.EndDate && DateAdd(minute, 30, p.StartDate) > item.StartDate);
        }     
    }
}
