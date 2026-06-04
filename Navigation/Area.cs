namespace Navigation;

public record Area(Realm Realm, string Name, int RelativeX, int RelativeY)
{
    public string FullName => $"{Realm.Name}.{Name}";

    // Area scale : 1'000 meters
    // Offset of Realm
    public int AbsoluteXInMeter => Realm.AbsoluteXInMeter + RelativeX * 1000;

    public int AbsoluteYInMeter => Realm.AbsoluteYInMeter + RelativeY * 1000;
}