using Spectre.Console;

namespace Console.States;

public abstract class GameStateBase
{
    protected GameStateBase(Layout locationLayout, Layout contentLayout, Layout actionsLayout)
    {
        LocationLayout = locationLayout;
        ContentLayout = contentLayout;
        ActionsLayout = actionsLayout;
    }

    protected Layout LocationLayout { get; }
    protected Layout ContentLayout { get; }
    protected Layout ActionsLayout { get; }

    public abstract void UpdateUI();

    public abstract bool ProcessPlayerInput(ConsoleKeyInfo keyInfo);
}
