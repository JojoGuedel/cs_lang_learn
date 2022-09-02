using System;

static class Application
{
    static ScreenContainer screen;

    static TextContainer topBarTitle;
    static LayoutContainer topBar;
    static LayoutContainer floorBar;

    static LayoutContainer body;

    static ConsoleKeyInfo lastKey;

    static bool active;

    public static void Init()
    {
        const int width = 120;
        const int height = 30;

        Console.SetBufferSize(width, height);
        Console.CursorVisible = false;

        screen = new ScreenContainer(width, height, ContainerGrowDirection.TB);

        topBar = screen.AddLayoutContainer(1);
        body = screen.AddLayoutContainer(width - 2);
        floorBar = screen.AddLayoutContainer(1);

        topBarTitle = topBar.AddTextContainer(30);
    }

    public static void LoadStartMenu()
    {
        topBarTitle.TextBox.Write("Start Menu");
        LayoutContainer menu = body.AddLayoutContainer(30);

        TextContainer Practice = menu.AddTextContainer(1);
        Practice.TextBox.Write("Practice");

        TextContainer Edit = menu.AddTextContainer(1);
        Edit.TextBox.Write("Edit");

        TextContainer Download = menu.AddTextContainer(1);
        Download.TextBox.Write("Download");

        TextContainer Settings = menu.AddTextContainer(1);
        Settings.TextBox.Write("Settings");

        TextContainer Exit = menu.AddTextContainer(1);
        Exit.TextBox.Write("Exit");
        Exit.OnUpdate += ExitKeyUpdateCB;

        menu.IsSelected = true;
        Practice.IsSelected = true;

        screen.Render();
    }

    public static void Run()
    {
        active = true;
        while (active)
        {
            HandleKeys();

            screen.Update();
        }
    }

    static void HandleKeys()
    {
        if (!Console.KeyAvailable) {
            lastKey = new ConsoleKeyInfo();
            return;
        }

        lastKey = Console.ReadKey(true);
        switch (lastKey.Key)
        {
            case ConsoleKey.UpArrow:
                InvokeCursorUpdate(CursorDirection.UP);
                break;
            case ConsoleKey.DownArrow:
                InvokeCursorUpdate(CursorDirection.DOWN);
                break;
            case ConsoleKey.RightArrow:
                InvokeCursorUpdate(CursorDirection.RIGHT);
                break;
            case ConsoleKey.LeftArrow:
                InvokeCursorUpdate(CursorDirection.LEFT);
                break;
            case ConsoleKey.Tab:
                if (lastKey.Modifiers != ConsoleModifiers.Shift)
                    InvokeCursorUpdate(CursorDirection.NEXT);
                else
                    InvokeCursorUpdate(CursorDirection.PREVIOUS);
                break;
            default:
                break;
        }
    }

    static void ExitKeyUpdateCB(AContainer sender)
    {
        if (sender.IsSelected && lastKey.Key == ConsoleKey.Enter)
            InvokeExit();
    }

    public static void InvokeCursorUpdate(CursorDirection direction)
    {
        body.UpdateCursor(direction);
        screen.Render();
    }

    public static void InvokeExit()
    {
        active = false;
    }
}
