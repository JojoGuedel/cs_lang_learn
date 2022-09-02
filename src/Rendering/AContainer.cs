abstract class AContainer
{
    public abstract int Width { get; }
    public abstract int Height { get; }

    public delegate void DUpdate(AContainer sender);
    public event DUpdate? OnUpdate;

    public abstract bool IsSelected { get; set; }

    // public abstract AContainer Parent { get; }

    public abstract void Render(int x, int y, int maxWidth, int maxHeight);
    public abstract void Update();
    protected void InvokeUpdate() => OnUpdate?.Invoke(this);

    public abstract bool UpdateCursor(CursorDirection direction);
}
