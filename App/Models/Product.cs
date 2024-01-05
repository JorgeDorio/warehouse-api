using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Category { get; set; }
    public string? Subcategory { get; set; }
    public required string Brand { get; set; }
    public required string Model { get; set; }
    public string? Description { get; set; }
    public decimal PurchasePrice { get; set; }
    public int QuantityInStock { get; set; }
    public int MinimumStock { get; set; }
    public required ICollection<StockMovement> StockMovements { get; set; }
}