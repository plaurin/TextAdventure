using Navigation;
using Spectre.Console;

namespace Console.States;

public class GameState : IExitGame, IPopupMenu
{
    private GameStateBase _currentGameState;
    private GameStateBase? _persistedState;

    private readonly NavigationState _navigationState;
    private readonly MainMenuState _menuState;

    public GameState(NavigationSystem navigation, Layout locationLayout, Layout contentLayout, Layout actionsLayout)
    {
        _navigationState = new NavigationState(navigation, locationLayout, contentLayout, actionsLayout);
        _menuState = new MainMenuState(this, this, locationLayout, contentLayout, actionsLayout);

        _currentGameState = _navigationState;
    }

    public bool ShouldExit { get; private set; }

    public void UpdateUI()
    {
        _currentGameState.UpdateUI();
    }

    public void ProcessPlayerInput(ConsoleKeyInfo keyInfo)
    {
        if (!_currentGameState.ProcessPlayerInput(keyInfo))
            if (keyInfo.Key == ConsoleKey.Escape) // Main Menu
            {
                _persistedState = _currentGameState;
                _currentGameState = _menuState;
            }
    }

    public void ExitGameRequest()
    {
        ShouldExit = true;
    }

    public void ClosePopop()
    {
        _currentGameState = _persistedState!;
        _persistedState = null;
    }
}