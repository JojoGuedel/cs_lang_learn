using System;

interface IAppearanceModifier
{
    public abstract void SetColor(ConsoleColor foregroundColor, ConsoleColor backgroundColor);
    public abstract void InvertColor();
}
