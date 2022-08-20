using System;
using System.Collections.Generic;

// enum TextOrientation
// {
//     LEFT_RIGHT,
//     RIGHT_LEFT,
//     TOP_DOWN,
//     DOWN_TOP,
// }

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