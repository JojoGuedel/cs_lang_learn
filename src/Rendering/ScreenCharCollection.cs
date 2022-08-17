using System;

class ScreenCharCollection 
{
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

    public void SetColor(ConsoleColor color, ConsoleColor backgroundColor) 
    {
        for (int i = 0; i < Size; i++)
        {
            Content[i].Color = color;
            Content[i].BackgroundColor = backgroundColor;
        }
    }
}