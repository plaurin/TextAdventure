using Navigation;
using static UnitTests.TestUtilities;

namespace UnitTests.Navigation;

public class NavigationSystemTests
{
    private NavigationSystem _sut;

    public NavigationSystemTests()
    {
        var l1 = CreateLocation("A.B.C");
        var l2 = CreateLocation("A.B.D");
        var l3 = CreateLocation("A.B.E");
        var locations = new List<Location>() { l1, l2, l3 };

        _sut = new NavigationSystem(locations, l1);
    }

    [Fact]
    public void CurrentPosition()
    {
        Assert.Equal("C", _sut.CurrentLocation.Name);
    }

    [Fact]
    public void AvailableDestinations()
    {
        Assert.Equal(2, _sut.AvailableDestinations.Count());
        Assert.Equal("D", _sut.AvailableDestinations.ElementAt(0).Name);
        Assert.Equal("E", _sut.AvailableDestinations.ElementAt(1).Name);
    }

    [Fact]
    public void MoveToLocation()
    {
        _sut.MoveTo(_sut.AvailableDestinations.ElementAt(0)); // D

        Assert.Equal("D", _sut.CurrentLocation.Name);

        Assert.Equal(2, _sut.AvailableDestinations.Count());
        Assert.Equal("C", _sut.AvailableDestinations.ElementAt(0).Name);
        Assert.Equal("E", _sut.AvailableDestinations.ElementAt(1).Name);
    } 
}
