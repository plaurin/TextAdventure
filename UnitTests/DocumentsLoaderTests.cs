using Data;

namespace UnitTests;

public class DocumentsLoaderTests
{
    [Fact]
    public void LoadFirstLocation()
    {
        var repoRoot = PathUtilities.GetRepoRoot();
        var locations = DocumentsLoader.Load(Path.Combine(repoRoot, @"UnitTests\Files\TestLocation.toml"));

        Assert.Equal(3, locations.Count());
        Assert.Equal("Main", locations.First().Area.Realm.Name);
        Assert.Equal("City", locations.First().Area.Name);
        Assert.Equal("CentralFountain", locations.First().Name);
    }

    [Fact]
    public void LoadWithCoordinates()
    {
        var repoRoot = PathUtilities.GetRepoRoot();
        var locations = DocumentsLoader.Load(Path.Combine(repoRoot, @"UnitTests\Files\TestLocation.toml"));

        var weaponShop = locations.Single(l => l.Name == "Inn");

        // Location
        Assert.Equal(-3, weaponShop.RelativeX);
        Assert.Equal(2, weaponShop.RelativeY);

        // Area
        Assert.Equal(5, weaponShop.Area.RelativeX);
        Assert.Equal(3, weaponShop.Area.RelativeY);

        // Realm
        Assert.Equal(1, weaponShop.Area.Realm.RelativeX);
        Assert.Equal(-1, weaponShop.Area.Realm.RelativeY);
    }
}
