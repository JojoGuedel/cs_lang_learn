using System.Collections.Generic;

abstract class ALayoutContainer : AContainer
{
    public abstract List<AContainer> Children { get; } 
    public abstract ContainerGrowDirection GrowDirection { get; }

    protected ContainerGrowDirection childGrowDirection;

    public LayoutContainer AddLayoutContainer(int widthOrHeight)
    {
        LayoutContainer layoutContainer = new LayoutContainer(this, widthOrHeight, childGrowDirection);
        Children.Add(layoutContainer);
        return layoutContainer;
    }

    public TextContainer AddTextContainer(int widthOrHeight)
    {
        int w = Width;
        int h = Height;

        if (GrowDirection == ContainerGrowDirection.LR)
            w = widthOrHeight;
        else if (GrowDirection == ContainerGrowDirection.TB)
            h = widthOrHeight;

        TextContainer textContainer = new TextContainer(this, w, h);
        Children.Add(textContainer);
        return textContainer;
    }

    public override void Render(int x, int y, int maxWidth, int maxHeight)
    {
        int anchorX = x;
        int anchorY = y;

        foreach (AContainer child in Children)
        {
            child.Render(anchorX, anchorY, maxWidth, maxHeight);
            
            if (GrowDirection == ContainerGrowDirection.LR)
                anchorX += child.Width;
            else if (GrowDirection == ContainerGrowDirection.TB)
                anchorY += child.Height;
        }
    }
}
