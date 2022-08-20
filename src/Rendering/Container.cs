using System;
using System.Collections.Generic;


abstract class Container
{
    public abstract int Width { get; }
    public abstract int Height { get; }

    public abstract Container Parent { get; }

    public abstract void Render(int x, int y);
    public virtual void Render(int x, int y, int maxWidth, int maxHeight) => Render(x, y);
}

class ScreenContainer<T> : Container
{
    public override Container Parent => throw new MemberAccessException("ScreenContainer does not have parents");

    public override int Width => Console.BufferWidth;
    public override int Height => Console.BufferHeight;

    Container container;
    public Container? Container { get => container; }

    // This constructor is probably illegal...
    public ScreenContainer(object?[]? args = null) 
    {
        if (!typeof(T).IsInstanceOfType(typeof(Container)))
            throw new Exception($"Invalid <T> '{typeof(T)}'. <T> must be instance of abstract class 'Container'");
        
        object? obj= Activator.CreateInstance(typeof(T), args);
        if (obj == null)
            throw new Exception("Activator returned null");
        
        container = (Container)obj;
    }

    public override void Render(int x = 0, int y = 0)
    {
        container.Render(x, y, Width - x, Height - y);
    }
}

class RowContainer : Container
{
    public List<ColumnContainer> columns;

    Container parent;
    public override Container Parent => parent;
    int height;

    public override int Width => Parent.Width;
    public override int Height => height;


    public RowContainer(int height, Container parent)
    {
        this.parent = Parent;
        columns = new List<ColumnContainer>();

        this.height = height;
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

    public override void Render(int x, int y) => Render(x, y, Width, Height);
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

            anchorY += column.Height;
        }
    }
}

class ColumnContainer : Container
{
    public List<RowContainer> rows;

    Container parent;
    public override Container Parent => parent;
    int height;

    public override int Width => Parent.Width;
    public override int Height => height;


    public ColumnContainer(int height, Container parent)
    {
        this.parent = Parent;
        rows = new List<RowContainer>();

        this.height = height;
    }

    public RowContainer AddColumn(int height)
    {
        RowContainer row = new RowContainer(height, this);
        rows.Add(row);
        return row;
    }

    public void RemoveColumn(RowContainer row)
    {
        rows.Remove(row);
    }

    public override void Render(int x, int y) => Render(x, y, Width, Height);
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