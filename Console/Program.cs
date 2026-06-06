using Console;
using Console.States;
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

var gameState = new GameState(navigation, locationLayout, contentLayout, actionsLayout);

AnsiConsole.Live(layout)
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
