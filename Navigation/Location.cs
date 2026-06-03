namespace Navigation;

public record Location(Area Area, string Name)
{
    public string FullName => $"{Area.FullName}.{Name}";
}
