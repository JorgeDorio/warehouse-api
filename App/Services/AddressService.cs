using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Warehouse.Data;
using Warehouse.Models;
using Warehouse.Errors;

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
}