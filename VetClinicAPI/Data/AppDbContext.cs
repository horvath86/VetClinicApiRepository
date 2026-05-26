using Microsoft.EntityFrameworkCore;
using VetClinicAPI.Models;

namespace VetClinicAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Veterinarian> Veterinarians { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
