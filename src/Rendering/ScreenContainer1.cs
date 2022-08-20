using System;
using System.Collections.Generic;

class ScreenContainer1
{
    public delegate void DOnChanged(ScreenContainer1 obj);
    public event DOnChanged? OnChanged;

    public int X { get; private set; }
    public int Y { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }

    public ScreenCharCollection Content { get; private set; } 

    public ScreenContainer1(int x, int y, int width, int height)
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

enum Direction
{
    Up,
    Down,
    Left,
    Right,
}

interface ISelectable
{
    public abstract void Select();
    public abstract void Deselect();

    public abstract bool MoveCursor(Direction direction);
}

abstract class Container1
{
    public int X { get; protected set; }
    public int Y { get; protected set; }
    public int Width { get; protected set; }
    public int Height { get; protected set; }

    public abstract void Draw();
    public abstract void Update();

    public delegate void DOnChanged(Container1 sender);
    public event DOnChanged? OnChanged;

    public Container1(int x, int y, int width, int height) 
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public void InvokeOnChanged() 
    {
        OnChanged?.Invoke(this);
    }
}

class LayoutContainer : Container1
{
    List<Container1> Containers;

    bool Selected;

    public LayoutContainer(int x, int y, int width, int height) : base(x, y, width, height)
    {
        Containers = new List<Container1>();
    }

    public override void Draw()
    {
        foreach (Container1 container in Containers)
            container.Draw();
    }

    public override void Update()
    {
        foreach (Container1 container in Containers)
            container.Update();
    }

    public void Select() 
    {
        Selected = true;
    }

    public void Deselect() 
    {
        Selected = false;
    }

    Container1? GetNextSelecteable(int x, int y) 
    {
        Container1? ret = null;
        
        foreach (Container1 container in Containers)
        {
            if (!(container is ISelectable))
                continue;

            if (container.X < X || container.Y < Y)
                continue;

            if (ret is null)
            {
                ret = container;
                continue;
            }

            if (container.X < ret.X || container.Y < ret.Y)
                continue;

            ret = container;
        }

        return ret;
    }

    Container1? GetPreviousSelectable(int x, int y) 
    {
        Container1? ret = null;
        
        foreach (Container1 container in Containers)
        {
            if (!(container is ISelectable))
                continue;

            if (container.X > X || container.Y > Y)
                continue;

            if (ret is null)
            {
                ret = container;
                continue;
            }

            if (container.X > ret.X || container.Y > ret.Y)
                continue;

            ret = container;
        }

        return ret;
    }
}

class TextContainer : Container1, ISelectable
{
    ScreenTextAlign ContentAlign;
    List<ScreenChar> ContentBuffer;

    bool Selected;

    public TextContainer(int x, int y, int width, int height) : base(x, y, width, height)
    {
        ContentAlign = ScreenTextAlign.LEFT;
        ContentBuffer = new List<ScreenChar>();

        for (int i = 0; i < width * height; i++)
            ContentBuffer.Add(new ScreenChar());

        Selected = false;
    }

    public override void Draw()
    {
        for (int y = 0; y < Height; y++)
        {
            if (Y >= Height)
                break;

            Console.SetCursorPosition(X, Y + y);

            for (int x = 0; x < Width; x++)
            {
                if (X >= Width)
                    break;

                ContentBuffer[x + y * Width].Write(Selected);
            }
        }
    }

    public override void Update() {}

    public void Select()
    {
        Selected = true;
    }

    public void Deselect()
    {
        Selected = false;
    }

    public bool MoveCursor(Direction direction)
    {
        return false;
    }

    public void SetText(string text) 
    {
        int start = 0;
        int end = Math.Min(text.Length, Width * Height - start);

        switch (ContentAlign)
        {
            case ScreenTextAlign.LEFT: start = 0; break;
            case ScreenTextAlign.CENTER: start = Width / 2 - text.Length / 2; break;
            case ScreenTextAlign.RIGHT: start = Width - text.Length; break;
        }

        start = Math.Max(start, 0);

        for (int i = 0; i < end; i++)
            ContentBuffer[start + i].Char = text[i];
        
        InvokeOnChanged();
    }
} 
