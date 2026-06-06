using Spectre.Console;

namespace Console.States;

public abstract class GameStateBase
{
    protected GameStateBase(ConsoleLayouts layouts)
    {
        LocationLayout = layouts.LocationLayout;
        ContentLayout = layouts.ContentLayout;
        ActionsLayout = layouts.ActionsLayout;
        StatusLayout = layouts.StatusLayout;
    }

    protected Layout LocationLayout { get; }
    protected Layout ContentLayout { get; }
    protected Layout ActionsLayout { get; }
    protected Layout StatusLayout { get; }

    public abstract void UpdateUI();

    public abstract bool ProcessPlayerInput(ConsoleKeyInfo keyInfo);
}
