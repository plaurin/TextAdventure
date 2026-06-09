using Console.States;
using Data;
using Navigation;
using Spectre.Console;
using Time;

var repoRoot = PathUtilities.GetRepoRoot();
var docs = DocumentsLoader.Load(Path.Combine(repoRoot, @"GameData\Locations\Main.City.toml"));

var realTime = new RealTimeSystem();
var navigation = new NavigationSystem(docs, docs.First(), realTime);

var locationLayout = new Layout().Size(3);
var contentLayout = new Layout();
var actionsLayout = new Layout().Size(3);
var statusLayout = new Layout().Size(20);

var rootLayout = new Layout("Root")
    .SplitRows(
        new Layout("Top")
            .SplitColumns(
                new Layout("Left")
                    .SplitRows(
                        locationLayout,
                        contentLayout),
                statusLayout),
        actionsLayout);

var layouts = new ConsoleLayouts(locationLayout, contentLayout, actionsLayout, statusLayout);

var gameState = new GameState(layouts, navigation, realTime);

AnsiConsole.Live(rootLayout)
    .Start(ctx =>
    {
        while (true)
        {
            gameState.UpdateUI();
            ctx.Refresh();

            var readKey = AnsiConsole.Console.Input.ReadKey(true);

            if (readKey.HasValue)
            {
                gameState.ProcessPlayerInput(readKey.Value);
            }

            if (gameState.ShouldExit)
                return;
        }
    });
