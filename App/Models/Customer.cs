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

    public required string Address { get; set; }

    public required string Password { get; set; }
}