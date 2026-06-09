using Time;

namespace UnitTests.RealTime;

public class RealTimeSystemTests
{
    [Theory]
    [InlineData(0, "A")]
    [InlineData(1, "B")]
    [InlineData(4, "E")]
    [InlineData(5, "A")]
    [InlineData(9, "E")]
    [InlineData(10, "A")]
    [InlineData(999998, "D")]
    public void DaysOfWeek(int daysToAdd, string expectedDay)
    {
        var sut = new RealTimeSystem();

        sut.SetDaysOfWeek("A", "B", "C", "D", "E");
        sut.AddTime(TimeSpan.FromDays(daysToAdd));

        Assert.Equal(expectedDay, sut.GameDayOfWeek);
    }

    [Theory]
    [InlineData(0, "1")]
    [InlineData(1, "2")]
    [InlineData(5, "6")]
    [InlineData(6, "1")]
    [InlineData(11, "6")]
    [InlineData(12, "1")]
    [InlineData(99999, "4")]
    public void MonthsOfYear(int monthsToAdd, string expectedMonth)
    {
        const int DaysPerMonth = 10;

        var sut = new RealTimeSystem();

        sut.SetMonthsOfYear("1", "2", "3", "4", "5", "6");
        sut.SetDaysPerMonth(DaysPerMonth);
        sut.AddTime(TimeSpan.FromDays(monthsToAdd * DaysPerMonth));

        Assert.Equal(expectedMonth, sut.GameMonthOfYear);
    }

    [Theory]
    [InlineData(30, 0, 1)]
    [InlineData(30, 1, 2)]
    [InlineData(30, 29, 30)]
    [InlineData(30, 30, 1)]
    [InlineData(30, 59, 30)]
    [InlineData(11, 0, 1)]
    [InlineData(11, 1, 2)]
    [InlineData(11, 10, 11)]
    [InlineData(11, 11, 1)]
    public void DaysOfMonth(int daysPerMonth, int daysToAdd, int expectedDayOfMonth)
    {
        var sut = new RealTimeSystem();

        sut.SetDaysPerMonth(daysPerMonth);
        sut.AddTime(TimeSpan.FromDays(daysToAdd));

        Assert.Equal(expectedDayOfMonth, sut.GameDay);
    }

    [Theory]
    [InlineData(0, 1, 1, 0, 0, 1, 1)]
    [InlineData(0, 1, 2, 0, 0, 1, 2)]
    [InlineData(0, 2, 1, 0, 0, 2, 1)]
    [InlineData(1, 1, 1, 0, 1, 1, 1)]
    [InlineData(1, 12, 30, 0, 1, 12, 30)]

    [InlineData(0, 1, 1, 1, 0, 1, 2)]
    [InlineData(0, 1, 1, 100, 0, 4, 11)]
    [InlineData(0, 1, 1, 1000, 2, 10, 11)]
    [InlineData(0, 1, 1, 10000, 27, 10, 11)]

    [InlineData(3, 2, 5, 100, 3, 5, 15)]
    [InlineData(5, 11, 5, 100, 6, 2, 15)]
    [InlineData(13, 6, 8, 100, 13, 9, 18)]

    [InlineData(2026, 6, 6, 40, 2026, 7, 16)]
    [InlineData(9999, 12, 30, 1, 10000, 1, 1)]
    public void SetGameStartTimeTestYearMonthDay(int year, int month, int day, int daysToAdd, int expectedYear, int expectedMonth, int expectedDay)
    {
        var sut = new RealTimeSystem();

        sut.SetGameStartTime(year, month, day, "MON");
        sut.AddTime(TimeSpan.FromDays(daysToAdd));

        var expected = $"Year {expectedYear} Month {expectedMonth} Day {expectedDay}";
        var actual = $"Year {sut.GameYear} Month {sut.GameMonth} Day {sut.GameDay}";

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0, 1, 1, "MON", 0, "MON")]
    [InlineData(0, 1, 1, "MON", 2, "WED")]
    [InlineData(0, 1, 1, "THU", 0, "THU")]
    [InlineData(0, 1, 1, "THU", 3, "SUN")]
    [InlineData(0, 1, 1, "FRI", 3, "MON")]

    [InlineData(0, 1, 2, "TUE", 1, "WED")]
    [InlineData(1, 1, 1, "SUN", 3, "WED")]
    [InlineData(2, 3, 4, "TUE", 3, "FRI")]
    [InlineData(9, 8, 7, "SAT", 3, "TUE")]
    public void SetGameStartTimeTestDayOfWeek(int year, int month, int day, string dayOfWeek, int daysToAdd, string expectedDayOfWeek)
    {
        var sut = new RealTimeSystem();

        sut.SetGameStartTime(year, month, day, dayOfWeek);
        sut.AddTime(TimeSpan.FromDays(daysToAdd));

        Assert.Equal(expectedDayOfWeek, sut.GameDayOfWeek);
    }

}
