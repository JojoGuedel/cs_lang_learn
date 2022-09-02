using System;

class MainMenu : View
{
    string title;
    public override string Title => title;

    public override View LastView { get; set; }
    public override bool IsCurrentView { get; set; }

    TextContainer practice;
    TextContainer edit;
    TextContainer download;
    TextContainer settings;
    TextContainer exit;

    public MainMenu()
    {
        title = "Main Menu";
    }

    public override void Load(ALayoutContainer canvas)
    {
        ForceGrowDirection(canvas, ContainerGrowDirection.LR);
        LayoutContainer menu = canvas.AddLayoutContainer(30);

        practice = menu.AddTextContainer(1);
        practice.TextBox.Write("Practice");

        edit = menu.AddTextContainer(1);
        edit.TextBox.Write("Edit");
        edit.OnUpdate += EditUpdate;

        download = menu.AddTextContainer(1);
        download.TextBox.Write("Download");

        settings = menu.AddTextContainer(1);
        settings.TextBox.Write("Settings");

        exit = menu.AddTextContainer(1);
        exit.TextBox.Write("Exit");
        exit.OnUpdate += ExitUpdateCB;

        menu.IsSelected = true;
        practice.IsSelected = true;
    }

    public override void Exit()
    {
        exit.OnUpdate -= ExitUpdateCB;
    }

    void EditUpdate(AContainer sender)
    {
    }

    void ExitUpdateCB(AContainer sender)
    {
        if (IsCurrentView && sender.IsSelected && Application.LastKey.Key == ConsoleKey.Enter)
            Application.ExitView();

        if (sender.IsSelected && Application.LastKey.Key == ConsoleKey.Enter)
            Application.InvokeExit();
    }
}
