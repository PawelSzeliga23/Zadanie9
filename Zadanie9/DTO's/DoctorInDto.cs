using System.ComponentModel.DataAnnotations;

namespace Zadanie9.DTO_s;

public class DoctorInDto
{
    [Required] public string? FirstName { get; set; }
    [Required] public string? LastName { get; set; }
    [Required] [EmailAddress] public string? Email { get; set; }
}