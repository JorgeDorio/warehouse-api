namespace Warehouse.Errors;

public class NotFoundException : Exception
{
    public string Name { get; }

    public NotFoundException(string name)
        : base($"{name} não encontrado")
    {
        Name = name;
    }
}
