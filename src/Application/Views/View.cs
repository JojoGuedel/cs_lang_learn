abstract class View
{
    public abstract bool IsCurrentView { get; set; }

    public abstract string Title { get; }
    public abstract View LastView { get; set; }

    public abstract void Load(ALayoutContainer canvas);
    public abstract void Exit();

    public void ForceGrowDirection(ALayoutContainer container, ContainerGrowDirection growDirection)
    {
        if (growDirection == ContainerGrowDirection.LR && container.GrowDirection == ContainerGrowDirection.TB)
            container = container.AddLayoutContainer(container.Height);
        else if (growDirection == ContainerGrowDirection.TB && container.GrowDirection == ContainerGrowDirection.LR)
            container = container.AddLayoutContainer(container.Width);
    }
}
