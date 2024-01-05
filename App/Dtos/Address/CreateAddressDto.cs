using System.ComponentModel.DataAnnotations;

namespace Warehouse.Dtos.Address;

public class CreateAddressDto
{
    [Required(ErrorMessage = "O apelido do endereço é obrigatório")]
    public required string Surname { get; set; }

    [Required(ErrorMessage = "O CEP do endereço é obrigatório")]
    [StringLength(8, ErrorMessage = "CEP inválido")]
    public required string Cep { get; set; }

    public string? Complement { get; set; }

    [Required(ErrorMessage = "O bairro do endereço é obrigatório")]
    public required string Neighborhood { get; set; }

    [Required(ErrorMessage = "A cidade do endereço é obrigatória")]
    public required string City { get; set; }

    [Required(ErrorMessage = "O estado do endereço é obrigatório")]
    public required string State { get; set; }

    [Required]
    public required int CustomerId { get; set; }
}