using System;
using System.Collections.Generic;

enum TextOrientation
{
    LEFT_RIGHT,
    RIGHT_LEFT,
    TOP_DOWN,
    DOWN_TOP,
}

enum HorizontalTextAlign
{
    LEFT,
    CENTER,
    RIGHT,
}

enum VerticalTextAlign
{
    TOP,
    CENTER,
    BOTTOM,
}

class ScreenWord : IAppearanceModifier
{
    public List<ScreenChar> Chars { get; private set; }

    public ScreenWord(List<ScreenChar> chars)
    {
        Chars = chars;
    }

    public void InvertColor()
    {
        foreach (ScreenChar c in Chars)
            c.InvertColor();
    }

    public void SetColor(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
    {
        foreach (ScreenChar c in Chars)
            c.SetColor(foregroundColor, backgroundColor);
    }
}

class ScreenText : IAppearanceModifier
{
    public List<ScreenWord> Words { get; private set; }

    public ScreenText(List<ScreenWord> words)
    {

    }

    public void InvertColor()
    {
        foreach (ScreenWord word in Words)
            word.InvertColor();
    }

    public void SetColor(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
    {
        foreach (ScreenWord word in Words)
            word.SetColor(foregroundColor, backgroundColor);
    }
}

class TextBox1
{
    int Width;
    int Height;

    ScreenChar[] ScreenBuffer;

    ScreenText text;
    ScreenText Text
    {
        get => text;
        set
        {
            text = value;
            UpdateBuffer();
        }
    }

    public TextBox1(int width, int height)
    {
        Width = width;
        Height = height;

        ScreenBuffer = new ScreenChar[Width * Height];

    }

    int IX(int x, int y)
    {
        return x + y * Width;
    }

    void UpdateBuffer()
    {
        List<List<ScreenChar>> Words = new List<List<ScreenChar>>();

        ScreenChar[] buffer = new ScreenChar[Width * Height];

        int lineWidth, lineCount;

        int lineCursor = 0;





    }

    void Render(int x, int y, int maxWidth, int maxHeight)
    {
        for (int _y = 0; _y < Height; y++)
        {
            if (y + _y > maxHeight)
                return;

            if (y + _y < 0)
                continue;

            Console.SetCursorPosition(x, y + _y);

            for (int _x = 0; _x < Width; _x++)
            {
                if (x + _x > maxWidth)
                    break;

                if (x + _x < 0)
                    continue;

                ScreenBuffer[IX(_x, _y)].Write();
            }
        }
    }
}

class TextBoxFormatter
{
    public string[] Words { get; }
    public int Width { get; }
    public int Height { get; }

    List<string>[] LineBuffer;

    public TextBoxFormatter(string[] words, int width, int height)
    {
        Words = words;

        Width = width;
        Height = height;


        LineBuffer = new List<string>[Height];
        for (int i = 0; i < LineBuffer.Length; i++)
            LineBuffer[i] = new List<string>();
    }

    public void Format()
    {
        for (int i = 0; i < LineBuffer.Length; i++)
        {
        }
    }

    

    public void SetHorizontalAlign(HorizontalTextAlign align)
    {
    }

    public void SetVerticalAlign(VerticalTextAlign align)
    {

    }
}