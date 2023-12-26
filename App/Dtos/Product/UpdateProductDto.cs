using System.ComponentModel.DataAnnotations;

namespace Warehouse.Dtos.Product;

public class UpdateProductDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "O nome do produto é obrigatório")]
    public required string Name { get; set; }

    public string? Category { get; set; }

    public string? Subcategory { get; set; }

    [Required(ErrorMessage = "A marca do produto é obrigatória")]
    public required string Brand { get; set; }

    [Required(ErrorMessage = "O modelo do produto é obrigatório")]
    public required string Model { get; set; }

    public string? Description { get; set; }

    public int? MinimumStock { get; set; } = 0;
}