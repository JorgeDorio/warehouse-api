namespace Warehouse;

public static class Settings
{
    public static readonly string? JwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
    public static readonly string? ConnectionString = Environment.GetEnvironmentVariable("DATABASE_URL");
}