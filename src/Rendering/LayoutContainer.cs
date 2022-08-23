using System.Collections.Generic;

class LayoutContainer : ALayoutContainer
{
    List<AContainer> children;
    public override List<AContainer> Children => children;

    ContainerGrowDirection growDirection;
    public override ContainerGrowDirection GrowDirection => growDirection;

    int width;
    int height;

    public override int Width => width;
    public override int Height => height;

    AContainer parent;
    public override AContainer Parent => parent;

    public LayoutContainer(AContainer parent, int widthOrHeight, ContainerGrowDirection growDirection) 
    {
        this.parent = parent;

        children = new List<AContainer>();
        this.growDirection = growDirection;

        width = parent.Width;
        height = parent.Height;

        if (growDirection == ContainerGrowDirection.LR)
        {
            width = widthOrHeight;
            childGrowDirection = ContainerGrowDirection.TB;
        }
        else if (growDirection == ContainerGrowDirection.TB)
        {
            height = widthOrHeight;
            childGrowDirection = ContainerGrowDirection.LR;
        }
    }
}
