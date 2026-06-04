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
}