using System;

struct ScreenChar : IAppearanceModifier
{
    char Char;

    ConsoleColor ForegroundColor;
    ConsoleColor BackgroundColor;

    public void InvertColor()
    {
        ConsoleColor temp = ForegroundColor;
        ForegroundColor = BackgroundColor;
        BackgroundColor = temp;
    }

    public void SetColor(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
    {
        ForegroundColor = foregroundColor;
        BackgroundColor = backgroundColor;
    }

    public void Write()
    {
        Console.ForegroundColor = ForegroundColor;
        Console.BackgroundColor = BackgroundColor;

        Console.Write(Char);
    }
}