using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointmentBooking.Models
{
    public class Availability
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey("ProviderId")]
        public string ProviderId { get; set; }
        [ForeignKey("AppointmentId")]
        public string AppointmentId { get; set; }
        public Provider Provider { get; set; }
        public Appointment Appointment { get; set; }
    }
}