using System;
using System.Collections.Generic;

class ColumnContainer : AColumnContainer 
{
    public List<RowContainer> rows;

    public ColumnContainer(int width, AContainer1 parent) : base(width, parent)
    {
        rows = new List<RowContainer>();
    }

    public RowContainer AddRow(int height)
    {
        height = Math.Min(height, Height);

        RowContainer row = new RowContainer(height, this);
        rows.Add(row);
        return row;
    }

    public void RemoveRow(RowContainer row)
    {
        rows.Remove(row);
    }

    public override void Render(int x, int y, int maxWidth, int maxHeight)
    {
        int anchorX = x;
        int anchorY = y;

        foreach(RowContainer row in rows) 
        {
            if (anchorY > maxHeight)
                return;

            if (anchorY + row.Height < 0)
                continue;

            row.Render(anchorX, anchorY, maxWidth, maxHeight - anchorY);

            anchorY += row.Height;
        }
    }
}
