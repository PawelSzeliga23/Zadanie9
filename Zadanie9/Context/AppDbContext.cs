using Microsoft.EntityFrameworkCore;
using Zadanie9.EfConfiguration;
using Zadanie9.Models;

namespace Zadanie9.Context;

public class AppDbContext : DbContext
{
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }


    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MedicamentEfConfiguration());
        modelBuilder.ApplyConfiguration(new PrescriptionEfConfiguration());
        modelBuilder.ApplyConfiguration(new PrescriptionMedicamentEfConfiguration());
        modelBuilder.ApplyConfiguration(new PatientEfConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorEfConfiguration());
    }
}