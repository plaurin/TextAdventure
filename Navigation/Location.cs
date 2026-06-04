namespace Navigation;

public record Location(Area Area, string Name, int RelativeX, int RelativeY)
{
    public string FullName => $"{Area.FullName}.{Name}";

    // Location scale : 10 meters
    public int AbsoluteXInMeter => Area.AbsoluteXInMeter + RelativeX * 10;

    public int AbsoluteYInMeter => Area.AbsoluteYInMeter + RelativeY * 10;
}
