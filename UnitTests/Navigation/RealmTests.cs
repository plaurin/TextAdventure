using static UnitTests.TestUtilities;

namespace UnitTests.Navigation;

public class RealmTests
{
    [Fact]
    public void RealmAbsoluteCoordinates()
    {
        var realm = CreateRealm("A", -1, 2);

        Assert.Equal(-100_000, realm.AbsoluteXInMeter);
        Assert.Equal(200_000, realm.AbsoluteYInMeter);
    }
}