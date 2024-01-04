using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models;

public class Customer
{
    [Key]
    public int Id { get; set; }

    public required string Name { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Phone]
    public required string Phone { get; set; }

    [StringLength(11)]
    public required string Cpf { get; set; }

    public required DateTime Birth { get; set; }
}