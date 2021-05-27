using MedicalAppointmentBooking.Models;
using System.Collections.Generic;


namespace MedicalAppointmentBooking.Services
{
    public interface IPatientService
    {
        List<Patient> GetAllPatient();
        Patient GetPatientById(string idPatient);
        void DeletePatient(Patient item);
        Patient NewPatient(Patient item);

        Patient EditPatient(Patient item);

    }
}
