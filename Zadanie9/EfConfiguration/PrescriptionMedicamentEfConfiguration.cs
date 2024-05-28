using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zadanie9.Models;

namespace Zadanie9.EfConfiguration;

public class PrescriptionMedicamentEfConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
    {
        builder.ToTable("Prescription_Medicament");

        builder.HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });

        builder.Property(pm => pm.Dose).IsRequired();
        builder.Property(pm => pm.Details).HasMaxLength(100).IsRequired();

        builder.HasOne(pm => pm.Medicament)
            .WithMany(m => m.PrescriptionMedicaments)
            .HasForeignKey(pm => pm.IdMedicament);

        builder.HasOne(pm => pm.Prescription)
            .WithMany(p => p.PrescriptionMedicaments)
            .HasForeignKey(pm => pm.IdPrescription);

        builder.HasData(new List<PrescriptionMedicament>()
        {
            new PrescriptionMedicament()
            {
                IdPrescription = 1,
                IdMedicament = 1,
                Dose = 2,
                Details = "Po jedzeniu"
            }
        });
    }
}