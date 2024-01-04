using System.ComponentModel.DataAnnotations;

namespace Warehouse.Dtos.Auth;

public class RegisterDto
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "O número de telefone é obrigatório")]
    [Phone]
    public required string Phone { get; set; }

    [Required(ErrorMessage = "O CPF é obrigatório")]
    [StringLength(11, ErrorMessage = "CPF inválido")]
    public required string Cpf { get; set; }

    [Required(ErrorMessage = "A data de nacimento é obrigatória")]
    public required DateTime Birth { get; set; }
}