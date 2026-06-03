using Console;
using Data;
using Navigation;
using Spectre.Console;

var repoRoot = PathUtilities.GetRepoRoot();
var docs = DocumentsLoader.Load(Path.Combine(repoRoot, @"GameData\Locations\Main.City.toml"));

var navigation = new NavigationSystem(docs, docs.First());

var locationLayout = new Layout().Size(3);
var contentLayout = new Layout();
var actionsLayout = new Layout(Renderer.RenderActions()).Size(3);

var layout = new Layout("Root")
    .SplitRows(
        locationLayout,
        contentLayout,
        actionsLayout);

AnsiConsole.Live(layout)
    .Start(ctx =>
    {

        int i = 1;

        while (true)
        {
            locationLayout.Update(Renderer.RenderLocation(navigation.CurrentLocation.FullName));
            contentLayout.Update(Renderer.RenderContent(navigation.AvailableDestinations));

            ctx.Refresh();
            var readKey = AnsiConsole.Console.Input.ReadKey(true);

            if (readKey?.Key == ConsoleKey.Escape)
                return;
        }
    });
