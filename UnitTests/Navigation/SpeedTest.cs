using Navigation;

namespace UnitTests.Navigation;

public class SpeedTest
{
    [Theory]
    [InlineData(3600, 1000)]
    [InlineData(360, 100)]
    [InlineData(36, 10)]
    [InlineData(20, 5.55)]
    [InlineData(5, 1.38)]
    [InlineData(2, 0.55)]
    [InlineData(1, 0.27)]
    public void MetersPerSecond(int speedKmh, double expectedMeterPerSecond)
    {
        var sut = new Speed();
        sut.SetSpeed(speedKmh);

        Assert.Equal(expectedMeterPerSecond, sut.MeterPerSecond, 0.01);
    }
}