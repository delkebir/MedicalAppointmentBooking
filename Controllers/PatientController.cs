using MedicalAppointmentBooking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedicalAppointmentBooking.Controllers
{
    public class PatientController : ApiController
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        // GET: api/Patient
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Patient/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Patient
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Patient/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Patient/5
        public void Delete(int id)
        {
        }
    }
}
