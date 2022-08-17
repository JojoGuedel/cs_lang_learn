using System;

class ScreenChar
{
    public char Char { get; set; }
    public bool Inverted { get; private set; }

    public ConsoleColor Color { get; set; }
    public ConsoleColor BackgroundColor { get; set; }

    public ScreenChar(char c = ' ')
    {
        Char = c;

        // TODO: Make this a setting
        Color = ConsoleColor.White;
        BackgroundColor = ConsoleColor.Black;
    }

    public bool Equals(ScreenChar other)
    {
        return (
            Char == other.Char &&
            Color == other.Color &&
            BackgroundColor == other.BackgroundColor
        );
    }

    public ScreenChar Copy() 
    {
        ScreenChar c = new ScreenChar(Char);
        c.Color = Color;
        c.BackgroundColor = BackgroundColor;

        return c;
    }
}
