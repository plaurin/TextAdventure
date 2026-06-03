namespace Data;

public static class PathUtilities
{
    public static string GetRepoRoot()
    {
        var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
        while (!Directory.Exists(Path.Combine(path!, "GameData")) && path != null)
        {
            path = Path.GetDirectoryName(path);
        }

        return path!;
    }

}