using Microsoft.AspNetCore.Mvc;
using Zadanie9.Exceptions;
using Zadanie9.Services;

namespace Zadanie9.Controller;

[ApiController]
[Route("/api/prescription")]
public class PrescriptionController : ControllerBase
{
    private readonly IPrescriptionService _prescriptionService;

    public PrescriptionController(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPrescriptionAsync(int id)
    {
        try
        {
            var prescription = await _prescriptionService.GetPrescriptionAsync(id);
            return Ok(prescription);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}