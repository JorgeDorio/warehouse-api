using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models;

public class Customer
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string Cpf { get; set; }
    public required DateTime Birth { get; set; }
    public ICollection<Address>? Addresses { get; set; }

}