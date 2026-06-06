using Navigation;
using Time;

namespace Console.States;

public class GameState : IExitGame, IPopupMenu
{
    private GameStateBase _currentGameState;
    private GameStateBase? _persistedState;

    private readonly NavigationState _navigationState;
    private readonly MainMenuState _menuState;

    public GameState(ConsoleLayouts layouts, NavigationSystem navigation, RealTimeSystem realTime)
    {
        _navigationState = new NavigationState(navigation, realTime, layouts);
        _menuState = new MainMenuState(this, this, layouts);

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
