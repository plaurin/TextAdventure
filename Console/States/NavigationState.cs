using Navigation;
using Spectre.Console;
using Time;

namespace Console.States;

public class NavigationState : GameStateBase
{
    private readonly NavigationSystem _navigation;
    private readonly RealTimeSystem _realTime;

    public NavigationState(NavigationSystem navigation, RealTimeSystem realTime, ConsoleLayouts layouts)
        : base(layouts)
    {
        _navigation = navigation;
        _realTime = realTime;
    }

    public override void UpdateUI()
    {
        LocationLayout.IsVisible = true;
        ContentLayout.IsVisible = true;
        ActionsLayout.IsVisible = true;

        LocationLayout.Update(Renderer.RenderLocation(_navigation.CurrentLocation.FullName));
        ContentLayout.Update(Renderer.RenderContent(_navigation.CurrentLocation, _navigation.AvailableDestinations));
        StatusLayout.Update(Renderer.RenderStatus(_realTime));
    }

    public override bool ProcessPlayerInput(ConsoleKeyInfo keyInfo)
    {
        if (keyInfo.Key == ConsoleKey.D1 && _navigation.AvailableDestinations.Count() > 0)
        {
            _navigation.MoveTo(_navigation.AvailableDestinations.ElementAt(0));
            return true;
        }

        if (keyInfo.Key == ConsoleKey.D2 && _navigation.AvailableDestinations.Count() > 1)
        {
            _navigation.MoveTo(_navigation.AvailableDestinations.ElementAt(1));
            return true;
        }


        if (keyInfo.Key == ConsoleKey.D3 && _navigation.AvailableDestinations.Count() > 2)
        {
            _navigation.MoveTo(_navigation.AvailableDestinations.ElementAt(2));
            return true;
        }

        return false;
    }
}
