using System;

static class Application
{
    static ScreenContainer screen;

    static View currentView;
    static DefaultView defaultView;

    static ConsoleKeyInfo lastKey;
    public static ConsoleKeyInfo LastKey { get => lastKey; }

    static bool active;

    static Application()
    {
        const int width = 120;
        const int height = 30;

        Console.SetBufferSize(width, height);
        Console.CursorVisible = false;

        screen = new ScreenContainer(width, height, ContainerGrowDirection.TB);

        defaultView = new DefaultView();
        defaultView.Load(screen);
        currentView = defaultView;
    }

    public static void LoadView(View view)
    {
        defaultView.TopBarTitle.TextBox.Clear();
        defaultView.TopBarTitle.TextBox.Write(view.Title);


        currentView.IsCurrentView = false;
        view.LastView = currentView;
        currentView = view;
        currentView.IsCurrentView = true;

        defaultView.Body.ClearChildren();
        currentView.Load(defaultView.Body);
        
        screen.Render();
    }

    public static void ExitView()
    {
        defaultView.TopBarTitle.TextBox.Clear();
        defaultView.TopBarTitle.TextBox.Write(currentView.Title);

        currentView.Exit();
        currentView.IsCurrentView = false;
        currentView = currentView.LastView;
        currentView.IsCurrentView = true;

        defaultView.Body.ClearChildren();
        currentView.Load(defaultView.Body);

        
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

    public static void InvokeCursorUpdate(CursorDirection direction)
    {
        defaultView.Body.UpdateCursor(direction);
        screen.Render();
    }

    public static void InvokeExit()
    {
        active = false;
    }
}
