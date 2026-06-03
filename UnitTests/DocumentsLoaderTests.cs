using Data;

namespace UnitTests;

public class DocumentsLoaderTests
{
    [Fact]
    public void Load()
    {
        var repoRoot = PathUtilities.GetRepoRoot();
        var ll = DocumentsLoader.Load(Path.Combine(repoRoot, @"GameData\Locations\Main.City.toml"));

        Assert.Equal(3, ll.Count());
        Assert.Equal("City", ll.First().Area.Name);
        Assert.Equal("Main", ll.First().Area.Realm.Name);
    }

}
