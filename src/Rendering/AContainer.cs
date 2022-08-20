using System.Collections.Generic;

abstract class AContainer1
{
    public abstract int Width { get; }
    public abstract int Height { get; }

    public abstract AContainer1 Parent { get; }

    public abstract void Render(int x, int y, int maxWidth, int maxHeight);
}

enum ContainerGrowDirection
{
    // left to right
    LR,
    // top to bottom
    TB,
}

abstract class AContainer
{
    public abstract int Width { get; }
    public abstract int Height { get; }

    public abstract AContainer Parent { get; }

    public abstract void Render(int x, int y, int maxWidth, int maxHeight);
}

abstract class ALayoutContainer : AContainer
{
    public abstract List<AContainer> Children { get; } 
    public abstract ContainerGrowDirection GrowDirection { get; }

    protected ContainerGrowDirection childGrowDirection;

    public LayoutContainer AddLayoutContainer(int widthOrHeight)
    {
        LayoutContainer layoutContainer = new LayoutContainer(this, widthOrHeight, childGrowDirection);
        return layoutContainer;
    }

    public TextContainer AddTextContainer(int widthOrHeight)
    {
        TextContainer textContainer = new TextContainer(this, widthOrHeight);
        return textContainer;
    }
}

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

        width = -1;
        height = -1;

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

    public override void Render(int x, int y, int maxWidth, int maxHeight)
    {
        throw new System.NotImplementedException();
    }
}

class TextContainer : AContainer
{
    public override int Width => throw new System.NotImplementedException();
    public override int Height => throw new System.NotImplementedException();

    public override AContainer Parent => throw new System.NotImplementedException();

    public TextContainer(AContainer parent, int widthOrHeight, ContainerGrowDirection growDirection);
    {

    }

    public override void Render(int x, int y, int maxWidth, int maxHeight)
    {
        throw new System.NotImplementedException();
    }
}