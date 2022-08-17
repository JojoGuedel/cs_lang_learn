using System;

// TODO: I don't think this class is necessary so...
class ScreenContainer
{
    public delegate void DOnChanged(ScreenContainer obj);
    public event DOnChanged? OnChanged;

    public int X { get; private set; }
    public int Y { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }

    public ScreenCharCollection Content { get; private set; } 

    public ScreenContainer(int x, int y, int width, int height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;

        Content = new ScreenCharCollection(width * height);
        Content.OnChanged += OnContextChanged;
        // TODO: Make this a Setting
        Content.SetColor(ConsoleColor.Black, ConsoleColor.White);
    }

    public bool Contains(int x, int y)
    {
        if (x < X || x >= X + Width)
            return false;
        if (y < Y || y >= Y + Height)
            return false;

        return true;
    }

    public void OnContextChanged()
    {
        OnChanged?.Invoke(this);
    }
}
