using MedicalAppointmentBooking.Models;
using System.Collections.Generic;


namespace MedicalAppointmentBooking.Services
{
    public interface IAppointmentService
    {
        List<Appointment> GetAllAppointment();
        Appointment GetAppointmentById(string idProvider, string idPatient);
        void DeleteAppointment(Appointment item);
        Appointment NewAppointment(Appointment item);

        Appointment EditAppointment(Appointment item);
        List<Availability> GetAllAvailability();

    }
}
