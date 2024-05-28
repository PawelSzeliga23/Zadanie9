using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zadanie9.Models;

namespace Zadanie9.EfConfiguration;

public class PatientEfConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("Patient");

        builder.HasKey(e => e.IdPatient);
        builder.Property(e => e.IdPatient).ValueGeneratedOnAdd();

        builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();
        builder.Property(e => e.Birthdate).IsRequired();

        builder.HasMany(e => e.Prescriptions)
            .WithOne(p => p.Patient)
            .HasForeignKey(p => p.IdPatient)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(new List<Patient>()
        {
            new Patient()
            {
                IdPatient = 1,
                FirstName = "Marek",
                LastName = "Rybak",
                Birthdate = new DateTime(2000, 1, 1)
            },
            new Patient()
            {
                IdPatient = 2,
                FirstName = "Kasia",
                LastName = "Bąk",
                Birthdate = new DateTime(2002, 2, 2)
            }
        });
    }
}