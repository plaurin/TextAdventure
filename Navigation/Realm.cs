namespace Navigation;

public record Realm(string Name, int RelativeX, int RelativeY)
{
    // Realm scale : 100 kilometers
    public int AbsoluteXInMeter => RelativeX * 100 * 1000;

    public int AbsoluteYInMeter => RelativeY * 100 * 1000;
}
