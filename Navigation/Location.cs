namespace Navigation;

public record Location(Area Area, string Name, int RelativeX, int RelativeY)
{
    public string FullName => $"{Area.FullName}.{Name}";
}
