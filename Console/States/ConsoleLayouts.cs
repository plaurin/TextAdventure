using Spectre.Console;

namespace Console.States;

public record ConsoleLayouts(Layout LocationLayout, Layout ContentLayout, Layout ActionsLayout, Layout StatusLayout);