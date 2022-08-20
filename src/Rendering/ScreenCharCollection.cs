using System;

enum ScreenTextAlign {
    LEFT,
    RIGHT,
    CENTER,
}

// TODO: I don't think this class is necessary so...
class ScreenCharCollection 
{
    // TODO: make this into a interface
    public delegate void DOnChanged();
    public event DOnChanged? OnChanged;

    ScreenChar[] Content;
    public int Size { get => Content.Length; }

    public ScreenChar this[int index]
    {
        get => Content[index];
        set 
        { 
            if (Content[index].Equals(value))
                return;
            
            Content[index] = value.Copy();
            OnChanged?.Invoke();
        }
    }

    public ScreenCharCollection(int size)
    {
        Content = new ScreenChar[size];

        for (int i = 0; i < size; i++)
            Content[i] = new ScreenChar();
    }

    public void SetText(string text, ScreenTextAlign textAlgin = ScreenTextAlign.LEFT) 
    {
        int start = 0;

        switch (textAlgin)
        {
            case ScreenTextAlign.LEFT: start = 0; break;
            case ScreenTextAlign.CENTER: start = Size / 2 - text.Length / 2; break;
            case ScreenTextAlign.RIGHT: start = Size - text.Length; break;
        }

        for (int i = 0; i < text.Length; i++)
            Content[start + i].Char = text[i];
        
        OnChanged?.Invoke();
    }

    public void SetColor(ConsoleColor color, ConsoleColor backgroundColor) 
    {
        for (int i = 0; i < Size; i++)
        {
            Content[i].Color = color;
            Content[i].BackgroundColor = backgroundColor;
        }

        OnChanged?.Invoke();
    }
}