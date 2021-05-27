using MedicalAppointmentBooking.Models;
using MedicalAppointmentBooking.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedicalAppointmentBooking.Controllers
{
    public class ProviderController : ApiController
    {
        private readonly IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }
        [HttpGet]
        // GET: api/Provider
        public IHttpActionResult GetProvider()
        {
            try
            {
                dynamic jsonResult = new JObject();
                var result = new JObject();
                var lstProviders = _providerService.GetAllProvider();
                jsonResult.response = JObject.FromObject(new { response = result });
                return Ok(jsonResult);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        // GET: api/Provider/5
        public IHttpActionResult GetProviderById(string id)
        {
            try
            {
                dynamic jsonResult = new JObject();
                var result = new JObject();
                var provider = _providerService.GetProviderById(id);
                jsonResult.response = JObject.FromObject(new { response = result });
                return Ok(jsonResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        // POST: api/Provider
        public IHttpActionResult SaveNewProvider(Provider item)
        {
            try
            {
                dynamic jsonResult = new JObject();
                var result = new JObject();
                var newProvider = _providerService.NewProvider(item);
                jsonResult.response = JObject.FromObject(new { response = result });
                return Ok(jsonResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        // PUT: api/Provider/5
        public IHttpActionResult EditProvider(Provider item)
        {
            try
            {
                dynamic jsonResult = new JObject();
                var result = new JObject();
                var editProvider = _providerService.EditProvider(item);
                jsonResult.response = JObject.FromObject(new { response = result });
                return Ok(jsonResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        // DELETE: api/Provider/5
        public IHttpActionResult DeleteProvider(Provider item)
        {
            try
            {
                _providerService.DeleteProvider(item);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
