using System.ComponentModel.DataAnnotations;

namespace Warehouse.Dtos.Auth;

public class LoginDto
{
    [StringLength(11)]
    public required string Cpf { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória")]
    public required string Password { get; set; }
}