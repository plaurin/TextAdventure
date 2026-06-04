using Navigation;

namespace UnitTests;

public static class TestUtilities
{
    public static Location CreateLocation(string fullname, int relativeX = 0, int relativeY = 0)
    {
        var segments = fullname.Split('.');
        var realm = new Realm(segments[0]);
        var aream = new Area(realm, segments[1]);
        return new Location(aream, segments[2], relativeX, relativeY);
    }
}