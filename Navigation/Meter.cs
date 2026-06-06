namespace Navigation;

public class Meter
{
    public static string Humanize(int meter)
    {
        var km = meter / 1000;

        if (km >= 10)
            return $"{km}km";
        if (km > 0)
        {
            meter -= km * 1000;
            var hundred = meter / 100;
            return $"{km}.{hundred}km";
        }
        else
            return $"{meter}m";
    }
}