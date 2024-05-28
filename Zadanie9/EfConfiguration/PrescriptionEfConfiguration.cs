using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zadanie9.Models;

namespace Zadanie9.EfConfiguration;

public class PrescriptionEfConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.ToTable("Prescription");

        builder.HasKey(p => p.IdPrescription);
        builder.Property(p => p.IdPrescription).ValueGeneratedOnAdd();

        builder.Property(p => p.Date).IsRequired();
        builder.Property(p => p.DueDate).IsRequired();

        builder.HasOne(p => p.Patient)
            .WithMany(p => p.Prescriptions)
            .HasForeignKey(p => p.IdPatient);

        builder.HasOne(p => p.Doctor)
            .WithMany(d => d.Prescriptions)
            .HasForeignKey(p => p.IdDoctor);

        builder.HasMany(p => p.PrescriptionMedicaments)
            .WithOne(pm => pm.Prescription)
            .HasForeignKey(pm => pm.IdPrescription)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(new List<Prescription>()
        {
            new Prescription()
            {
                IdPrescription = 1,
                Date = new DateTime(2024, 5, 28),
                DueDate = new DateTime(2024, 6, 28),
                IdPatient = 1,
                IdDoctor = 1
            }
        });
    }
}