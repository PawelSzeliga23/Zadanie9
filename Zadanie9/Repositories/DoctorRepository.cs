using Microsoft.EntityFrameworkCore;
using Zadanie9.Context;
using Zadanie9.DTO_s;
using Zadanie9.Exceptions;
using Zadanie9.Models;

namespace Zadanie9.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly AppDbContext _context;

    public DoctorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<DoctorOutDto> GetDoctorAsync(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor == null)
        {
            throw new NotFoundException($"Doctor with id {id} not found");
        }

        return new DoctorOutDto
        {
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            Email = doctor.Email
        };
    }

    public async Task<IEnumerable<DoctorOutDto>> GetDoctorsAsync()
    {
        var doctors = await _context.Doctors.Select(d => new DoctorOutDto
        {
            FirstName = d.FirstName,
            LastName = d.LastName,
            Email = d.Email
        }).ToListAsync();
        return doctors;
    }

    public async Task<Doctor> AddDoctorAsync(DoctorInDto dto)
    {
        var doctor = new Doctor
        {
            FirstName = dto.FirstName!,
            LastName = dto.LastName!,
            Email = dto.Email!
        };
        await _context.Doctors.AddAsync(doctor);
        await _context.SaveChangesAsync();
        return doctor;
    }

    public async Task<Doctor> UpdateDoctorAsync(int id, DoctorInDto dto)
    {
        try
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                throw new NotFoundException($"Doctor with id {id} not found");
            }

            doctor.FirstName = dto.FirstName!;
            doctor.LastName = dto.LastName!;
            doctor.Email = dto.Email!;
            await _context.SaveChangesAsync();
            return doctor;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Doctor> DeleteDoctorAsync(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor == null)
        {
            throw new NotFoundException($"Doctor with id {id} not found");
        }

        _context.Doctors.Remove(doctor);
        await _context.SaveChangesAsync();
        return doctor;
    }
}

public interface IDoctorRepository
{
    public Task<DoctorOutDto> GetDoctorAsync(int id);
    public Task<IEnumerable<DoctorOutDto>> GetDoctorsAsync();
    public Task<Doctor> AddDoctorAsync(DoctorInDto dto);
    public Task<Doctor> UpdateDoctorAsync(int id, DoctorInDto dto);
    public Task<Doctor> DeleteDoctorAsync(int id);
}