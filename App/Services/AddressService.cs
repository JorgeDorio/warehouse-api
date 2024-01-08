using Warehouse.Data;
using Warehouse.Models;

namespace Warehouse.Services;

public class AddressService
{
    private readonly Context _context;

    public AddressService(Context context)
    {
        _context = context;
    }

    public async Task Create(Address address)
    {
        _context.Add(address);
        await _context.SaveChangesAsync();
    }

    public IEnumerable<Address> ReadByCustomerId(int id)
    {
        var result = _context.Adresses.Where(a => a.CustomerId == id);
        return result;
    }
}