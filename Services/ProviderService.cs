using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MedicalAppointmentBooking.MedicalAppointmentDataContext;
using MedicalAppointmentBooking.Models;

namespace MedicalAppointmentBooking.Services
{
    public class ProviderService : IProviderService
    {
        private MedicalAppointmentContext _context;
        public ProviderService(MedicalAppointmentContext context)
        {
            _context = context;
        }

        public List<Provider> GetAllProvider()
        {
            var lstProvider = _context.Providers.ToList();
            if (lstProvider.Count > 0)
                return lstProvider;
            return null;
        }
        public Provider GetProviderById(string idProvider)
        {
            var prdr = _context.Providers.Where(app => app.Id.Equals(idProvider)).FirstOrDefault();
            if (prdr != null)
                return prdr;
            else
                return null;
        }
        public void DeleteProvider(Provider item)
        {
            _context.Providers.Remove(item);
        }
        public Provider NewProvider(Provider item)
        {
            var newProvider = new Provider()
            {
                IdClinic = item.IdClinic,
                FirstName = item.FirstName,
                LastName = item.LastName
            };
            _context.Entry(newProvider).State = EntityState.Added;
            _context.SaveChanges();
            return newProvider;
        }
        public Provider EditProvider(Provider item)
        {

            var EditProvider = GetProviderById(item.Id);
            if (EditProvider != null)
            {
                EditProvider.IdClinic = item.IdClinic;
                EditProvider.FirstName = item.FirstName;
                EditProvider.LastName = item.LastName;
            }
            _context.Entry(EditProvider).State = EntityState.Modified;
            _context.SaveChanges();
            return EditProvider;
        }
        protected void Dispose(bool disposing)
        {
            _context.Dispose();
            Dispose(disposing);
        }
    }
}