using System;
using System.Collections.Generic;

class ScreenContainer : ALayoutContainer
{
    List<AContainer> children;
    public override List<AContainer> Children => children;

    ContainerGrowDirection growDirection;
    public override ContainerGrowDirection GrowDirection => growDirection;

    int width;
    int height;

    public override int Width => width;
    public override int Height => height;

    // public override AContainer Parent => throw new MemberAccessException("ScreenContainer does not have parents.");

    public ScreenContainer(int width, int height, ContainerGrowDirection growDirection)
    {
        this.width = width;
        this.height = height;

        children = new List<AContainer>();
        this.growDirection = growDirection;
    }

    public void Render()
    {
        this.Render(0, 0, Width, Height);
    }
}