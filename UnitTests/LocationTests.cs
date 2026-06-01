using Navigation;

namespace UnitTests
{
    public class LocationTests
    {
        [Fact]
        public void Test1()
        {
            var r = new Realm("Toto");
            var a = new Area(r, "Lili");
            var l = new Location(a, "Nana");
        }

        [Fact]
        public void Load()
        {
            var repoRoot = GetRepoRoot();
            var ll = LocationLoader.Load(Path.Combine(repoRoot, @"GameData\Locations\Main.City.toml"));

            Assert.Equal(3, ll.Count());
            Assert.Equal("City", ll.First().Area.Name);
            Assert.Equal("Main", ll.First().Area.Realm.Name);
            // C:\Users\pasca\Dev\GitHub\TextAdventure\GameData\Locations\test.toml
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
}
