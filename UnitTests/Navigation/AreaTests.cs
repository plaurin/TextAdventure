using static UnitTests.TestUtilities;

namespace UnitTests.Navigation;

public class AreaTests
{
    [Fact]
    public void AreaAbsoluteCoordinates()
    {
        var area = CreateArea("A.B", 2, -3);

        Assert.Equal(2000, area.AbsoluteXInMeter);
        Assert.Equal(-3000, area.AbsoluteYInMeter);
    }

    [Theory]
    [InlineData(0, 0, 0, 0, 0, 0)]
    [InlineData(0, 0, 2, -3, 2000, -3000)]
    [InlineData(-1, 1, 0, 0, -100_000, 100_000)]
    [InlineData(-1, 1, 2, -3, 2000 - 100_000, -3000 + 100_000)]
    [InlineData(4, 3, 2, -3, 2000 + 400_000, -3000 + 300_000)]
    public void AreaAbsoluteCoordinatesWithOffsettedRealm(int realmX, int realmY, int areaX, int areaY, int expectedX, int expectedY)
    {
        var realm = CreateRealm("A", realmX, realmY);
        var area = CreateArea(realm, "B", areaX, areaY);

        Assert.Equal(expectedX, area.AbsoluteXInMeter);
        Assert.Equal(expectedY, area.AbsoluteYInMeter);
    }
}
