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
}