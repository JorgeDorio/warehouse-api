using System.ComponentModel.DataAnnotations;

namespace Warehouse.Dtos.Auth;

public class RegisterDto
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório")]
    [EmailAddress]
    public required string Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória")]
    public required string Password { get; set; }

    [Required(ErrorMessage = "O número de telefone é obrigatório")]
    [Phone]
    public required string Phone { get; set; }

    [Required(ErrorMessage = "O endereço é obrigatório")]
    public required string Address { get; set; }
}