using Time;

namespace Navigation;

public class NavigationSystem(IEnumerable<Location> allLocations, Location initialLocation, RealTimeSystem realTime)
{
    private readonly IEnumerable<Location> _locations = allLocations;
    private readonly RealTimeSystem _realTime = realTime;

    public Location CurrentLocation { get; private set; } = initialLocation;

    public IEnumerable<Location> AvailableDestinations => _locations.Except([CurrentLocation]);

    public void MoveTo(Location location)
    {
        if (AvailableDestinations.Contains(location))
        {
            var distance = CurrentLocation.DistanceTo(location);
            _realTime.AddTime(TimeSpan.FromMinutes(distance));

            CurrentLocation = location;
        }
    }

    public void SetInitializeCurrentLocation(Location initialLocation)
    {
        CurrentLocation = initialLocation;
    }
}