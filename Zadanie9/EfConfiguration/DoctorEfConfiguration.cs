using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zadanie9.Models;

namespace Zadanie9.EfConfiguration;

public class DoctorEfConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("Doctor");

        builder.HasKey(d => d.IdDoctor);
        builder.Property(d => d.IdDoctor).ValueGeneratedOnAdd();

        builder.Property(d => d.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(d => d.LastName).HasMaxLength(100).IsRequired();
        builder.Property(d => d.Email).HasMaxLength(100).IsRequired();

        builder.HasMany(d => d.Prescriptions)
            .WithOne(p => p.Doctor)
            .HasForeignKey(p => p.IdDoctor)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasData(new List<Doctor>()
        {
            new Doctor()
            {
                IdDoctor = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "jankow@wp.pl"
            },
            new Doctor()
            {
                IdDoctor = 2,
                FirstName = "Anna",
                LastName = "Nowak",
                Email = "anowak@gmail.com"
            }
        });
    }
}