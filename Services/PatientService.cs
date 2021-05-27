using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MedicalAppointmentBooking.MedicalAppointmentDataContext;
using MedicalAppointmentBooking.Models;

namespace MedicalAppointmentBooking.Services
{
    public class PatientService : IPatientService
    {
        private MedicalAppointmentContext _context;
        public PatientService(MedicalAppointmentContext context)
        {
            _context = context;
        }
        public List<Patient> GetAllPatient()
        {
            var lstPatient = _context.Patients.ToList();
            if (lstPatient.Count > 0)
                return lstPatient;
            return null;
        }
        public Patient GetPatientById(string idPatient)
        {
            var prdr = _context.Patients.Where(app => app.Id.Equals(idPatient)).FirstOrDefault();
            if (prdr != null)
                return prdr;
            else
                return null;             
        }
        public void DeletePatient(Patient item)
        {
            _context.Patients.Remove(item);                      
        }        
        public Patient NewPatient(Patient item)
        {
            var newPatient = new Patient()
            {
                IdClinic = item.IdClinic,
                FirstName = item.FirstName,
                LastName = item.LastName
            };
            _context.Entry(newPatient).State = EntityState.Added;
            _context.SaveChanges();
            return newPatient;
        }
        public Patient EditPatient(Patient item)
        {

            var EditPatient = GetPatientById(item.Id);
            if (EditPatient != null)
            {
                EditPatient.IdClinic = item.IdClinic;
                EditPatient.FirstName = item.FirstName;
                EditPatient.LastName = item.LastName;
            }
            _context.Entry(EditPatient).State = EntityState.Modified;
            _context.SaveChanges();
            return EditPatient;
        }
        protected void Dispose(bool disposing)
        {
            _context.Dispose();
            Dispose(disposing);
        }
    }
}