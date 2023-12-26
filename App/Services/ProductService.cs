using Warehouse.Data;
using Warehouse.Errors;
using Warehouse.Models;

namespace Warehouse.Services;

public class ProductService
{
    private readonly Context _context;

    public ProductService(Context context)
    {
        _context = context;
    }

    public async Task Create(Product product)
    {
        _context.Add(product);
        await _context.SaveChangesAsync();
    }

    public IEnumerable<Product> ReadAll()
    {
        var result = _context.Products.ToList();
        return result;
    }

    public Product ReadById(int id)
    {
        var result = _context.Products.Where(p => p.Id == id).SingleOrDefault();
        if (result == null) throw new NotFoundException("Produto");
        return result;
    }

    public async Task Delete(int id)
    {
        var product = ReadById(id);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Product product)
    {
        _context.Update(product);
        await _context.SaveChangesAsync();
    }
}