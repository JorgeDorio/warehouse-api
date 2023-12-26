namespace Warehouse.Models;

using System.ComponentModel.DataAnnotations;

public class StockMovement
{
    [Key]
    public int Id { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public required string Type { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public decimal Value { get; set; }
    public int ProductId { get; set; }
    public required Product Product { get; set; }
    public int SupplierId { get; set; }
    public required Supplier Supplier { get; set; }
}