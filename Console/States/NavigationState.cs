using Navigation;
using Spectre.Console;

namespace Console.States;

public class NavigationState : GameStateBase
{
    private readonly NavigationSystem _navigation;

    public NavigationState(NavigationSystem navigation, Layout locationLayout, Layout contentLayout, Layout actionsLayout)
        : base(locationLayout, contentLayout, actionsLayout)
    {
        _navigation = navigation;
    }

    public override void UpdateUI()
    {
        LocationLayout.IsVisible = true;
        ContentLayout.IsVisible = true;
        ActionsLayout.IsVisible = true;

        LocationLayout.Update(Renderer.RenderLocation(_navigation.CurrentLocation.FullName));
        ContentLayout.Update(Renderer.RenderContent(_navigation.CurrentLocation, _navigation.AvailableDestinations));
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
