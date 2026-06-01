namespace Navigation;

public record Area(Realm Realm, string Name)
{
    public string FullName => $"{Realm.Name}.{Name}";
}