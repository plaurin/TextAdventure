using Navigation;

namespace UnitTests;

public class DocumentsLoaderTests
{
    [Fact]
    public void Load()
    {
        var repoRoot = GetRepoRoot();
        var ll = DocumentsLoader.Load(Path.Combine(repoRoot, @"GameData\Locations\Main.City.toml"));

        Assert.Equal(3, ll.Count());
        Assert.Equal("City", ll.First().Area.Name);
        Assert.Equal("Main", ll.First().Area.Realm.Name);
    }

    private string GetRepoRoot()
    {
        var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
        while (!Directory.Exists(Path.Combine(path, "GameData")) && path != null)
        {
            path = Path.GetDirectoryName(path);
        }

        return path;
    }
}
