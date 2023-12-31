using System.ComponentModel.DataAnnotations;

namespace Warehouse.Dtos.Auth;

public class LoginDto
{
    [Required(ErrorMessage = "O e-mail é obrigatório")]
    [EmailAddress]
    public required string Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória")]
    public required string Password { get; set; }
}