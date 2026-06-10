namespace Navigation;

public class Speed
{
    private const int MeterPerKm = 1000;
    private const int SecondPerHour = 60 * 60;

    public const int WalkingKmh = 5;
    public const int JoggingKmh = 10;
    public const int RunningKmh = 20;
    
    private int _speedKmh = WalkingKmh;

    public void SetSpeed(int kmh)
    {
        _speedKmh = kmh;
    }

    public double MeterPerSecond => (double)_speedKmh * MeterPerKm / SecondPerHour;

    public TimeSpan GetRequiredTimeToTraval(double meters)
    {
        return TimeSpan.FromSeconds(meters / MeterPerSecond);
    }
}