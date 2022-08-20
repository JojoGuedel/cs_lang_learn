using System;
using System.Collections.Generic;

class RowContainer : ARowContainer 
{
    public List<ColumnContainer> columns;

    public RowContainer(int height, AContainer parent) : base(height, parent)
    {
        columns = new List<ColumnContainer>();
    }

    public ColumnContainer AddColumn(int width)
    {
        width = Math.Min(width, Width);

        ColumnContainer column = new ColumnContainer(width, this);
        columns.Add(column);
        return column;
    }

    public void RemoveColumn(ColumnContainer column)
    {
        columns.Remove(column);
    }

    public override void Render(int x, int y, int maxWidth, int maxHeight)
    {
        int anchorX = x;
        int anchorY = y;

        foreach(ColumnContainer column in columns) 
        {
            if (anchorX > maxWidth)
                return;

            if (anchorX + column.Width < 0)
                continue;

            column.Render(anchorX, anchorY, maxWidth - anchorX, maxHeight);

            anchorX += column.Width;
        }
    }
}
