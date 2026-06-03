using Navigation;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Console
{
    public static class Renderer
    {
        public static IRenderable RenderLocation(string? currentLocation = null)
        {
            currentLocation ??= "No location";

            var content = new Text(currentLocation);

            var locationPanel = new Panel(content)
                .Header("Location")
                .RoundedBorder()
                .BorderColor(Color.Green)
                .Expand();

            return locationPanel;
        }

        public static IRenderable RenderContent(int iteration)
        {
            var content = new Text($"Iteration {iteration}");

            return new Panel(content)
                .RoundedBorder()
                .BorderColor(Color.Blue)
                .Expand();
        }

        public static IRenderable RenderContent(IEnumerable<Location> availableDestinations)
        {
            var table = new Table();
            table.AddColumn("Destination");

            foreach (var item in availableDestinations)
            {
                table.AddRow(item.FullName);
            }

            return new Panel(table)
                .RoundedBorder()
                .BorderColor(Color.Blue)
                .Expand();
        }

        public static IRenderable RenderActions()
        {
            var actionsPanel = new Panel(string.Empty)
                .Header("Actions")
                .RoundedBorder()
                .BorderColor(Color.Red)
                .Expand();

            return actionsPanel;
        }
    }
}
