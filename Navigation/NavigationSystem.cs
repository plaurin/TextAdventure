using Time;

namespace Navigation;

public class NavigationSystem(IEnumerable<Location> allLocations, Location initialLocation, RealTimeSystem realTime)
{
    private readonly IEnumerable<Location> _locations = allLocations;
    private readonly RealTimeSystem _realTime = realTime;
    private readonly Speed _speed = new();

    public Location CurrentLocation { get; private set; } = initialLocation;

    public IEnumerable<Location> AvailableDestinations => _locations.Except([CurrentLocation]);
    
    public void SetSpeed(int kilometersHour)
    {
        _speed.SetSpeed(kilometersHour);
    }

    public void MoveTo(Location location)
    {
        if (AvailableDestinations.Contains(location))
        {
            var distance = CurrentLocation.DistanceTo(location);

            var requiredTime = _speed.GetRequiredTimeToTraval(distance);

            _realTime.AddTime(requiredTime);

            CurrentLocation = location;
        }
    }

    public void SetInitializeCurrentLocation(Location initialLocation)
    {
        CurrentLocation = initialLocation;
    }
}
