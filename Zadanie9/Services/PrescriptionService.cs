using Zadanie9.DTO_s;
using Zadanie9.Repositories;

namespace Zadanie9.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly IPrescriptionRepository _repository;

    public PrescriptionService(IPrescriptionRepository repository)
    {
        _repository = repository;
    }

    public async Task<PrescriptionOutDto> GetPrescriptionAsync(int id)
    {
        return await _repository.GetPrescriptionAsync(id);
    }
}

public interface IPrescriptionService
{
    public Task<PrescriptionOutDto> GetPrescriptionAsync(int id);
}