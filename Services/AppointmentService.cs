using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MedicalAppointmentBooking.MedicalAppointmentDataContext;
using MedicalAppointmentBooking.Models;

namespace MedicalAppointmentBooking.Services
{
    public class AppointmentService : IAppointmentService
    {
        private MedicalAppointmentContext _context;

        public AppointmentService(MedicalAppointmentContext context)
        {
            _context = context;
        }
        public List<Appointment> GetAllAppointment()
        {
            var lstAppointment = _context.Appointments.ToList();
            if (lstAppointment.Count > 0)
                return lstAppointment;
            return null;
        }
        public Appointment GetAppointmentById(string idProvider, string isPatient)
        {
            var prdr = _context.Appointments.Where(app => app.ProviderId.Equals(idProvider) && app.PatientId.Equals(isPatient)).FirstOrDefault();
            if (prdr != null)
                return prdr;
            else
                return null;        
          
        }

        public void DeleteAppointment(Appointment item)
        {
            _context.Appointments.Remove(item);
        }
        
        public Appointment NewAppointment(Appointment item)
        {
            var newAppointment = new Appointment()
            {
                PatientId = item.PatientId,
                ProviderId = item.ProviderId,
                StartDate = item.StartDate,
                EndDate = item.EndDate
            };
            _context.Entry(newAppointment).State = EntityState.Added;
            _context.SaveChanges();

            return newAppointment;
        }
        public Appointment EditAppointment(Appointment item)
        {

            var EditAppointment = GetAppointmentById(item.ProviderId, item.PatientId);
            if (EditAppointment != null)
            {

                EditAppointment.PatientId = item.PatientId;
                EditAppointment.ProviderId = item.ProviderId;
                EditAppointment.StartDate = item.StartDate;
                EditAppointment.EndDate = item.EndDate;
            }
            _context.Entry(EditAppointment).State = EntityState.Modified;
            _context.SaveChanges();
            return EditAppointment;
        }
        public List<Availability> GetAllAvailability()
        {
            var lstAvailability = _context.Availabilities.ToList();
            if (lstAvailability.Count > 0)
                return lstAvailability;
            return null;
        }
        protected void Dispose(bool disposing)
        {
            _context.Dispose();
            Dispose(disposing);
        }
    }
}