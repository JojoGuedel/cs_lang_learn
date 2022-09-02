using System;

class DefaultView : View
{
    string title;
    public override string Title => throw new NotImplementedException();

    LayoutContainer topBar;
    public LayoutContainer TopBar { get => topBar; }

    TextContainer topBarTitle;
    public TextContainer TopBarTitle { get => topBarTitle; }

    LayoutContainer body;
    public LayoutContainer Body { get => body; }

    LayoutContainer floorBar;
    public LayoutContainer FloorBar { get => floorBar; }

    public override View LastView { get; set; }
    public override bool IsCurrentView { get; set; }

    public DefaultView()
    {
        title = "Empty";
    }

    public override void Exit() {}

    public override void Load(ALayoutContainer canvas)
    {
        topBar = canvas.AddLayoutContainer(1);
        body = canvas.AddLayoutContainer(canvas.Height - 2);
        floorBar = canvas.AddLayoutContainer(1);

        topBarTitle = topBar.AddTextContainer(30);
    }
}
