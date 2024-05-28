using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zadanie9.Models;

namespace Zadanie9.EfConfiguration;

public class MedicamentEfConfiguration : IEntityTypeConfiguration<Medicament>
{
    public void Configure(EntityTypeBuilder<Medicament> builder)
    {
        builder.ToTable("Medicament");

        builder.HasKey(m => m.IdMedicament);
        builder.Property(m => m.IdMedicament).ValueGeneratedOnAdd();

        builder.Property(m => m.Name).HasMaxLength(100).IsRequired();
        builder.Property(m => m.Description).HasMaxLength(100).IsRequired();
        builder.Property(m => m.Type).HasMaxLength(100).IsRequired();

        builder.HasMany(m => m.PrescriptionMedicaments)
            .WithOne(pm => pm.Medicament)
            .HasForeignKey(pm => pm.IdMedicament)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(new List<Medicament>()
        {
            new Medicament()
            {
                IdMedicament = 1,
                Name = "Apap",
                Description = "Przeciwbólowy",
                Type = "Tabletki"
            },
            new Medicament()
            {
                IdMedicament = 2,
                Name = "Ibuprom",
                Description = "Przeciwzapalny",
                Type = "Tabletki"
            },
            new Medicament()
            {
                IdMedicament = 3,
                Name = "Rutinoscorbin",
                Description = "Witamina C",
                Type = "Tabletki"
            }
        });
    }
}