using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models;

public class Supplier
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public required string CNPJ { get; set; }
    public required string Address { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string Country { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public required ICollection<StockMovement> StockMovements { get; set; }
}