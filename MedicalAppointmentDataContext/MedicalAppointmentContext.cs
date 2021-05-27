using MedicalAppointmentBooking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MedicalAppointmentBooking.MedicalAppointmentDataContext
{
    public class MedicalAppointmentContext:DbContext
    {    
        public MedicalAppointmentContext() : base("MedicalAppointment")
        {
        }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Clinic> Clinics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure default schema
            base.OnModelCreating(modelBuilder);
            //Map entity to table
            modelBuilder.Entity<Clinic>().ToTable("Clinic", "dbo");
            modelBuilder.Entity<Patient>().ToTable("Patient", "dbo");
            modelBuilder.Entity<Provider>().ToTable("Provider", "dbo"); 
            modelBuilder.Entity<Appointment>().ToTable("Appointment", "dbo");
            modelBuilder.Entity<Availability>().ToTable("Availability", "dbo");
            //Configure primary key
            modelBuilder.Entity<Provider>().HasKey(s =>s.Id);
            modelBuilder.Entity<Patient>().HasKey(s => s.Id);
            modelBuilder.Entity<Clinic>().HasKey(s => s.Name);
            // configures one-to-many relationship
            modelBuilder.Entity<Provider>()
                .HasRequired<Clinic>(s => s.Clinic)
                .WithMany(g => g.Providers)
                .HasForeignKey(s => s.IdClinic); 
            modelBuilder.Entity<Patient>()
                .HasRequired<Clinic>(s => s.Clinic)
                .WithMany(g => g.Patients)
                .HasForeignKey(s => s.IdClinic);
            modelBuilder.Entity<Appointment>()
                .HasRequired<Provider>(s => s.Provider)
                .WithMany(g => g.Appointments)
                .HasForeignKey(s =>s.ProviderId);
            modelBuilder.Entity<Appointment>()
                .HasRequired<Patient>(s => s.Patient)
                .WithMany(g => g.Appointments)
                .HasForeignKey(s => s.PatientId);
            // Configure one-to-one relationship
            modelBuilder.Entity<Availability>()
                        .HasOptional(s => s.Appointment) // Mark Availability property optional in Appointment entity
                        .WithRequired(ad => ad.Availability); // mark Appointment property as required in Availibility entity. Cannot save Appointment without Availibility

        }
    }
}