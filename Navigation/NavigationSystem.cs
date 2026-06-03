namespace Navigation;

public class NavigationSystem(IEnumerable<Location> allLocations, Location initialLocation)
{
    private readonly IEnumerable<Location> _locations = allLocations;

    public Location CurrentLocation { get; private set; } = initialLocation;

    public IEnumerable<Location> AvailableDestinations => _locations.Except([CurrentLocation]);

    public void MoveTo(Location location)
    {
        if (AvailableDestinations.Contains(location))
        {
            CurrentLocation = location;
        }
    }

    public void SetInitializeCurrentLocation(Location initialLocation)
    {
        CurrentLocation = initialLocation;
    }
}