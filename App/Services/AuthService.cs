using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Warehouse.Data;
using Warehouse.Models;
using Warehouse.Errors;

namespace Warehouse.Services;

public class AuthService
{
    private readonly Context _context;

    public AuthService(Context context)
    {
        _context = context;
    }

    public async Task Register(Customer customer)
    {
        _context.Add(customer);
        await _context.SaveChangesAsync();
    }

    public bool CustomerHasRegister(string cpf)
    {
        var customer = _context.Customers.Where(c => c.Cpf == cpf).FirstOrDefault();
        if (customer != null) return true;
        return false;
    }
}