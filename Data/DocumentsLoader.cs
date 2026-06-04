using Navigation;
using System.Text.Json;
using Tomlyn;

namespace Data;

public class DocumentsLoader
{
    public static IEnumerable<Location> Load(string filename)
    {
        var tomlContent = File.ReadAllText(filename);

        var options = new TomlSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        var result = TomlSerializer.Deserialize<DocumentDto>(tomlContent, options);

        var realms = result!.Realms.Select(GetRealm);
        var areas = result!.Areas.Select(a => GetArea(realms, a));
        return result!.Locations.Select(l => GetLocation(areas, l));
    }

    private static Realm GetRealm(LocationDto realmDto)
    {
        if (realmDto.Name.Split('.').Length != 1) throw new Exception("Should not have . in the name of Realm");

        return new Realm(realmDto.Name);
    }

    private static Area GetArea(IEnumerable<Realm> realms, LocationDto areaDto)
    {
        var segments = areaDto.Name.Split('.');
        if (segments.Length != 2) throw new Exception("Should have 1 . in the name of Area (for Realm)");

        var realmName = segments[0];
        var realm = realms.Single(r => r.Name == realmName);

        var areaName = segments[1];
        return new Area(realm, areaName);
    }

    private static Location GetLocation(IEnumerable<Area> areas, LocationDto locationDto)
    {
        var segments = locationDto.Name.Split('.');
        if (segments.Length != 3) throw new Exception("Should have 2 . in the name of Location (for Realm and Area)");

        var realmName = segments[0];
        var areaName = segments[1];
        var locationName = segments[2];

        var area = areas.Single(a => a.FullName == $"{realmName}.{areaName}");
        return new Location(area, locationName, locationDto.Coordinates[0], locationDto.Coordinates[1]);
    }

    private class DocumentDto
    {
        public List<LocationDto> Locations { get; set; } = [];
        public List<LocationDto> Areas { get; set; } = [];
        public List<LocationDto> Realms { get; set; } = [];
    }

    private class LocationDto
    {
        public string Name { get; set; } = string.Empty;
        public int[] Coordinates { get; set; } = [];
        public string Description { get; set; } = string.Empty;
    }
}
