namespace Navigation;

public record Location(Area Area, string Name, int RelativeX, int RelativeY)
{
    public string FullName => $"{Area.FullName}.{Name}";

    // Location scale : 10 meters
    public int AbsoluteXInMeter => RelativeX * 10;

    public int AbsoluteYInMeter => RelativeY * 10;
}
