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
}