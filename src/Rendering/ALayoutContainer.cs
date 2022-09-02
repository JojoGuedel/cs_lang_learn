using System.Collections.Generic;

abstract class ALayoutContainer : AContainer
{
    public abstract List<AContainer> Children { get; } 
    public abstract ContainerGrowDirection GrowDirection { get; }

    protected bool isSelected;
    public override bool IsSelected { get => isSelected; set { if (value) Select(); else Deselect(); } }

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

        if (childGrowDirection == ContainerGrowDirection.LR)
            h = widthOrHeight;
        else if (childGrowDirection == ContainerGrowDirection.TB)
            w = widthOrHeight;

        TextContainer textContainer = new TextContainer(this, w, h);
        Children.Add(textContainer);
        return textContainer;
    }

    public void ResetChildren()
    {
        Children.Clear();
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

    public override void Update()
    {
        InvokeUpdate();

        foreach (AContainer child in Children)
            child.Update();
    }

    public override bool UpdateCursor(CursorDirection direction)
    {
        bool canUpdate = true;

        if ((direction == CursorDirection.UP || direction == CursorDirection.DOWN) && GrowDirection == ContainerGrowDirection.LR)
            canUpdate = false;
        
        if ((direction == CursorDirection.LEFT || direction == CursorDirection.RIGHT) && GrowDirection == ContainerGrowDirection.TB)
            canUpdate = false;

        for (int i = 0; i < Children.Count; i++)
        {
            if (Children[i].IsSelected) {
                if (Children[i].UpdateCursor(direction))
                    return true;
                else if (!canUpdate)
                    continue;

                switch (direction)
                {
                    case CursorDirection.UP:
                    case CursorDirection.LEFT:
                    case CursorDirection.PREVIOUS:
                        if (i > 0) 
                        {
                            Children[i].IsSelected = false;
                            Children[i - 1].IsSelected = true;
                            return true;
                        }
                    break;
                    case CursorDirection.DOWN:
                    case CursorDirection.RIGHT:
                    case CursorDirection.NEXT:
                        if (i < Children.Count - 1) 
                            {
                                Children[i].IsSelected = false;
                                Children[i + 1].IsSelected = true;
                                return true;
                            }
                    break;

                }
                break;
            }
        }

        return false;
    }

    void Select()
    {
        isSelected = true;
    }

    void Deselect()
    {
        isSelected = false;
    }
}
