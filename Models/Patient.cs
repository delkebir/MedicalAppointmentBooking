using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MedicalAppointmentBooking.Models
{
    public class Patient : IdentityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Patient> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("Id", this.FirstName + this.LastName));
            return userIdentity;
        }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ForeignKey("IdClinic")]
        public string IdClinic { get; set; }

        public Clinic Clinic { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}