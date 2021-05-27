using MedicalAppointmentBooking.Models;
using System.Collections.Generic;


namespace MedicalAppointmentBooking.Services
{
    public interface IProviderService
    {
        List<Provider> GetAllProvider();
        Provider GetProviderById(string idProvider);
        void DeleteProvider(Provider item);
        Provider NewProvider(Provider item);

        Provider EditProvider(Provider item);

    }
}
