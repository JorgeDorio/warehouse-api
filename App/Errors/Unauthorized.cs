namespace Warehouse.Errors;

public class UnauthorizedException : Exception
{
    public UnauthorizedException(string response) : base(response) { }
}
