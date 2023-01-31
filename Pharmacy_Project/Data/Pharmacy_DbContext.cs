
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pharmacy_Project.Api.Models;
using Pharmacy_Project.Bll;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Extend;
using System.Diagnostics.Metrics;

namespace Pharmacy_Project.Data
{
    public class Pharmacy_DbContext:IdentityDbContext<ApplicationUser>
    {
        public Pharmacy_DbContext(DbContextOptions<Pharmacy_DbContext> opts) : base(opts) { }

        public DbSet<Client> Client { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Areas> Areas { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Terms_Conditions> Terms_Conditions { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Complains> Complains { get; set; }
        public DbSet<Medical_Information> Medical_Information { get; set; }

        //Centers
        public DbSet<AnalysisLaps> AnalysisLaps { get; set; }
        public DbSet<Clincs> Clincs { get; set; }
        public DbSet<Hospitals> Hospitals { get; set; }
        public DbSet<MedicalCentres> MedicalCentres { get; set; }
        public DbSet<Pharmacies> Pharmacies { get; set; }
        public DbSet<Xrays> Xrays { get; set; }
        public DbSet<HomeSlider> HomeSlider { get; set; }

        //Aponiments
        public DbSet<ClincsAppointments> ClincsAppointments { get; set; }
        public DbSet<PharmaciesAppointments> PharmaciesAppointments { get; set; }
        public DbSet<XRaysAppointments> XRaysAppointments { get; set; }
        public DbSet<HospitalsAppointments> HospitalsAppointments { get; set; }
        public DbSet<AnalysisLapsAppointments> AnalysisLapsAppointments { get; set; }
        public DbSet<MedicalCentresAppointments> MedicalCentresAppointments { get; set; }

     


    }
}
