using System.Text.Json;
using Tomlyn;

namespace Navigation;

public class LocationLoader
{
    public LocationLoader(string filename)
    {
//        if (!File.Exists(filename)) throw new FileNotFoundException($"File not found: {filename}", filename);

        var tomlContent = File.ReadAllText(filename);

        var options = new TomlSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        var result = TomlSerializer.Deserialize<DocumentDto>(tomlContent, options);

        
    }

    public class AppConfig
    {
        public List<ServerInfo> Servers { get; set; } = [];
    }

    public class ServerInfo
    {
        public string Ip { get; set; }
        public int Port { get; set; }
    }

    public class DocumentDto
    {
        public List<LocationDto> Locations { get; set; } = [];
    }

    public class LocationDto
    {
        public string Name { get; set; }
        public int[] Coordinates { get; set; }
        public string Description { get; set; }
    }
}