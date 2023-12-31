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
        customer.Password = HashPassword(customer.Password);
        _context.Add(customer);
        await _context.SaveChangesAsync();
    }

    public string Login(Customer customer)
    {
        var user = _context.Customers.FirstOrDefault(c => c.Email == customer.Email);
        if (user == null)
        {
            throw new NotFoundException("Usuário");
        }

        if (VerifyPassword(customer.Password, user.Password))
        {
            var token = GenerateToken(user);
            return token;
        }
        else
        {
            throw new UnauthorizedException("Usuário ou senha invalidos");
        }
    }

    private static string HashPassword(string password)
    {
        var salt = GenerateSalt();
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);

        var hash = pbkdf2.GetBytes(20);
        return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
    }

    private static byte[] GenerateSalt()
    {
        var salt = new byte[16];
        RandomNumberGenerator.Fill(salt);
        return salt;
    }

    private static bool VerifyPassword(string password, string hashedPassword)
    {
        var parts = hashedPassword.Split(':');
        if (parts.Length != 2)
        {
            throw new FormatException("Invalid hashed password format");
        }
        var salt = Convert.FromBase64String(parts[0]);
        var storedHash = Convert.FromBase64String(parts[1]);

        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
        var computedHash = pbkdf2.GetBytes(20);

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != storedHash[i])
            {
                return false;
            }
        }
        return true;
    }

    public static string GenerateToken(Customer customer)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Settings.JwtSecret ?? "");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]{
                new Claim(ClaimTypes.Name,customer.Name)
            }),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}