using Zadanie9.DTO_s;
using Zadanie9.Models;
using Zadanie9.Repositories;

namespace Zadanie9.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _repository;

    public DoctorService(IDoctorRepository repository)
    {
        _repository = repository;
    }

    public async Task<DoctorOutDto> GetDoctorAsync(int id)
    {
        return await _repository.GetDoctorAsync(id);
    }

    public async Task<IEnumerable<DoctorOutDto>> GetDoctorsAsync()
    {
        return await _repository.GetDoctorsAsync();
    }

    public async Task<Doctor> AddDoctorAsync(DoctorInDto dto)
    {
        return await _repository.AddDoctorAsync(dto);
    }

    public async Task<Doctor> UpdateDoctorAsync(int id, DoctorInDto dto)
    {
        return await _repository.UpdateDoctorAsync(id, dto);
    }

    public async Task<Doctor> DeleteDoctorAsync(int id)
    {
        return await _repository.DeleteDoctorAsync(id);
    }
}

public interface IDoctorService
{
    public Task<DoctorOutDto> GetDoctorAsync(int id);
    public Task<IEnumerable<DoctorOutDto>> GetDoctorsAsync();
    public Task<Doctor> AddDoctorAsync(DoctorInDto dto);
    public Task<Doctor> UpdateDoctorAsync(int id, DoctorInDto dto);
    public Task<Doctor> DeleteDoctorAsync(int id);
}