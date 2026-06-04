namespace Navigation;

public record Location(Area Area, string Name, int RelativeX, int RelativeY)
{
    public string FullName => $"{Area.FullName}.{Name}";

    // Location scale : 10 meters
    public int AbsoluteXInMeter => Area.AbsoluteXInMeter + RelativeX * 10;

    public int AbsoluteYInMeter => Area.AbsoluteYInMeter + RelativeY * 10;

    public double DistanceTo(Location location)
    {
        return Math.Sqrt(Math.Pow(location.AbsoluteXInMeter - AbsoluteXInMeter, 2) + Math.Pow(location.AbsoluteYInMeter - AbsoluteYInMeter, 2));
    }
}
