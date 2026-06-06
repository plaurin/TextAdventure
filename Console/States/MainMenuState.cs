using Spectre.Console;

namespace Console.States;

public class MainMenuState : GameStateBase
{
    private readonly IPopupMenu _popupMenu;
    private readonly IExitGame _exitGame;

    public MainMenuState(IPopupMenu popupMenu, IExitGame exitGame, ConsoleLayouts layouts)
        : base(layouts)
    {
        _popupMenu = popupMenu;
        _exitGame = exitGame;
    }

    public override void UpdateUI()
    {
        LocationLayout.IsVisible = false;
        ContentLayout.IsVisible = true;
        ActionsLayout.IsVisible = false;

        ContentLayout.Update(new Panel(new Text("Menu - Q to exit - ESC to return to game"))
            .RoundedBorder()
            .BorderColor(Color.Purple)
            .Expand());
    }

    public override bool ProcessPlayerInput(ConsoleKeyInfo keyInfo)
    {
        if (keyInfo.Key == ConsoleKey.Q)
        {
            _exitGame.ExitGameRequest();
            return true;
        }

        if (keyInfo.Key == ConsoleKey.Escape)
        {
            _popupMenu.ClosePopop();
            return true;
        }

        return false;
    }
}