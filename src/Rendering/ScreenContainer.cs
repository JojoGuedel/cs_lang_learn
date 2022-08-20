using System;

class ScreenContainer : AContainer1
{
    public override AContainer1 Parent => throw new MemberAccessException("ScreenContainer does not have parents");

    public override int Width => Console.BufferWidth;
    public override int Height => Console.BufferHeight;

    public AContainer1? Container { get; private set; }

    public ColumnContainer AsColumnContainer() 
    {
        ColumnContainer column = new ColumnContainer(Height, this);
        Container = column;
        return column;
    }

    // TODO: set ConsoleBuffer
    public override void Render(int x = 0, int y = 0, int maxWidth = -1, int maxHeight = -1)
    {
        Container?.Render(x, y, Width - x, Height - y);
    }
}