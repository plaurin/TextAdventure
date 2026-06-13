using static UnitTests.TestUtilities;

namespace UnitTests.Navigation;

public class LocationTests
{
    [Fact]
    public void LocationAbsoluteCoordinates()
    {
        var location = CreateLocation("A.B.C", 5, 3);

        Assert.Equal(50, location.AbsoluteXInMeter);
        Assert.Equal(30, location.AbsoluteYInMeter);
    }

    [Theory]
    [InlineData(0, 0, 0, 0, 0, 0, 0, 0)]
    [InlineData(0, 0, 0, 0, 3, 5, 30, 50)]
    [InlineData(0, 0, 2, -3, 0, 0, 2000, -3000)]
    [InlineData(0, 0, 2, -3, -1, 6, 2000 - 10, -3000 + 60)]
    [InlineData(-1, 1, 0, 0, 0, 0, -100_000, 100_000)]
    [InlineData(-1, 1, 0, 0, -3, -4, -100_000 - 30, 100_000 - 40)]
    [InlineData(-1, 1, 2, -3, 0, 0, 2000 - 100_000, -3000 + 100_000)]
    [InlineData(-1, 1, 2, -3, 11, 12, 2000 - 100_000 + 110, -3000 + 100_000 + 120)]
    public void LocationAbsoluteCoordinatesWithOffsettedArea(int realmX, int realmY, int areaX, int areaY, int locationX, int locationY, int expectedX, int expectedY)
    {
        var realm = CreateRealm("A", realmX, realmY);
        var area = CreateArea(realm, "B", areaX, areaY);
        var location = CreateLocation(area, "C", locationX, locationY);

        Assert.Equal(expectedX, location.AbsoluteXInMeter);
        Assert.Equal(expectedY, location.AbsoluteYInMeter);
    }

    [Theory]
    [InlineData(0, 0, 0, 0, 0)]
    [InlineData(0, 1, 0, 0, 10)]
    [InlineData(1, 0, 0, 0, 10)]
    [InlineData(0, 0, 1, 0, 10)]
    [InlineData(0, 0, 0, 1, 10)]
    [InlineData(0, 0, 0, 15, 150)]
    [InlineData(3, 4, 0, 0, 50)]
    [InlineData(0, 0, 3, 4, 50)]
    [InlineData(10, 10, 13, 14, 50)]
    public void DistanceToAnotherLocation(int location1X, int location1Y, int location2X, int location2Y, double expectedDistance)
    {
        var location1 = CreateLocation("A.B.C", location1X, location1Y);
        var location2 = CreateLocation("A.B.D", location2X, location2Y);

        Assert.Equal(expectedDistance, location1.DistanceTo(location2));
    }

    [Theory]
    [InlineData("A.B.C", "A - B - C")]
    [InlineData("A.B.CenterTown", "A - B - Center Town")]
    [InlineData("TheRealm.TheArea.TheLocation", "The Realm - The Area - The Location")]
    public void Humanize(string fullLocation, string expectedHumanizedName)
    {
        var location = CreateLocation(fullLocation);

        Assert.Equal(expectedHumanizedName, location.HumanizedName);
    }
}