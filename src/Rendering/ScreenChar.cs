using System;

class ScreenChar
{
    public char Char { get; set; }

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

    public void Write() => Write(false);
    public void Write(bool Inverted) 
    {
        if (Inverted) 
        {
            Console.ForegroundColor = BackgroundColor;
            Console.BackgroundColor = Color;
        }
        else
        {
            Console.ForegroundColor = Color;
            Console.BackgroundColor = BackgroundColor;
        }

        Console.Write(Char);
    }
}
