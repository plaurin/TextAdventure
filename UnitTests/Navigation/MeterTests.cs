using Navigation;

namespace UnitTests.Navigation;

public class MeterTests
{
    [Theory]
    [InlineData(0, "0m")]
    [InlineData(1, "1m")]
    [InlineData(12, "12m")]
    [InlineData(234, "234m")]
    [InlineData(999, "999m")]
    [InlineData(1_000, "1.0km")]
    [InlineData(1_099, "1.0km")]
    [InlineData(1_100, "1.1km")]
    [InlineData(5_200, "5.2km")]
    [InlineData(9_999, "9.9km")]
    [InlineData(10_000, "10km")]
    [InlineData(10_999, "10km")]
    [InlineData(11_000, "11km")]
    [InlineData(99_999, "99km")]
    public void Humanize(int meter, string expected)
    {
        var result = Meter.Humanize(meter);

        Assert.Equal(expected, result);
    }
}