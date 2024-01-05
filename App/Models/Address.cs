using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Models;

public class Address
{
    [Key]
    public int Id { get; set; }
    public required string Surname { get; set; }
    public required string Cep { get; set; }
    public string? Complement { get; set; }
    public required string Neighborhood { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }

    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public required Customer Customer { get; set; }
}