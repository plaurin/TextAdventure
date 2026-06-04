namespace Navigation;

public record Area(Realm Realm, string Name, int RelativeX, int RelativeY)
{
    public string FullName => $"{Realm.Name}.{Name}";

    // Area scale : 1'000 meters
    public int AbsoluteXInMeter => RelativeX * 1000;

    public int AbsoluteYInMeter => RelativeY * 1000;
}