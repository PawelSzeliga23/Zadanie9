using Microsoft.EntityFrameworkCore;
using Zadanie9.Context;
using Zadanie9.DTO_s;
using Zadanie9.Exceptions;
using Zadanie9.Models;

namespace Zadanie9.Repositories;

public class PrescriptionRepository : IPrescriptionRepository
{
    private readonly AppDbContext _context;

    public PrescriptionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PrescriptionOutDto> GetPrescriptionAsync(int id)
    {
        var prescription = await _context.Prescriptions.FindAsync(id);
        if (prescription == null)
        {
            throw new NotFoundException($"Prescription with id {id} not found");
        }

        var doctor = await _context.Doctors
            .Where(d => d.IdDoctor == prescription.IdDoctor)
            .Select(d => new DoctorOutDto()
            {
                FirstName = d!.FirstName,
                LastName = d.LastName,
                Email = d.Email
            })
            .FirstOrDefaultAsync();
        var patient = await _context.Patients
            .Where(p => p.IdPatient == prescription.IdPatient)
            .Select(p => new PatientOutDto()
            {
                FirstName = p!.FirstName,
                LastName = p.LastName,
                Birthdate = p.Birthdate
            })
            .FirstOrDefaultAsync();
        var medicaments = await _context.PrescriptionMedicaments
            .Where(pm => pm.IdPrescription == id)
            .Select(pm => pm.Medicament)
            .ToListAsync();
        var medicamentsDto = medicaments.Select(m => new MedicamentDto()
        {
            Name = m.Name,
            Description = m.Description,
            Type = m.Type
        }).ToList();
        var result = new PrescriptionOutDto()
        {
            IdPrescription = prescription.IdPrescription,
            Date = prescription.Date,
            DueDate = prescription.DueDate,
            Doctor = doctor!,
            Patient = patient!,
            Medicaments = medicamentsDto
        };
        return result;
    }
}

public interface IPrescriptionRepository
{
    public Task<PrescriptionOutDto> GetPrescriptionAsync(int id);
}