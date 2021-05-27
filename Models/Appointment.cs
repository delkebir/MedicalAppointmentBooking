using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointmentBooking.Models
{
    public class Appointment
    {
        public Provider Provider { get; set; }
        public Patient Patient { get; set; }
        [ForeignKey("AvailabilityId")]
        public string AvailabilityId { get; set; }
        public Availability Availability { get; set; }
        [ForeignKey("ProviderId")]
        public string ProviderId { get; set; }
        [ForeignKey("PatientId")]
        public string PatientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double VisitSpan { get; set; }
        public string Day { get; set; }
    }
}