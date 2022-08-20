abstract class AContainer
{
    public abstract int Width { get; }
    public abstract int Height { get; }

    public abstract AContainer Parent { get; }

    public abstract void Render(int x, int y, int maxWidth, int maxHeight);
}