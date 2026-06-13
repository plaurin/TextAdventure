using System.Text.RegularExpressions;

namespace Navigation;

public partial record Location(Area Area, string Name, int RelativeX, int RelativeY)
{
    public string FullName => $"{Area.FullName}.{Name}";

    public string HumanizedName => $"{SplitPascalCase(Area.Realm.Name)} - {SplitPascalCase(Area.Name)} - {SplitPascalCase(Name)}";

    // Location scale : 10 meters
    public int AbsoluteXInMeter => Area.AbsoluteXInMeter + RelativeX * 10;

    public int AbsoluteYInMeter => Area.AbsoluteYInMeter + RelativeY * 10;

    public double DistanceTo(Location location)
    {
        return Math.Sqrt(Math.Pow(location.AbsoluteXInMeter - AbsoluteXInMeter, 2) + Math.Pow(location.AbsoluteYInMeter - AbsoluteYInMeter, 2));
    }

    private static string SplitPascalCase(string input)
    {
        string result = ToSplitPascalCase().Replace(input, " ");

        return result;
    }

    [GeneratedRegex(@"(?<=[a-z0-9])(?=[A-Z])")]
    private static partial Regex ToSplitPascalCase();
}
