using System;

class TextColumnContainer : AColumnContainer
{
    public TextBox TextBox { get; private set; }

    public TextColumnContainer(int width, AContainer1 parent) : this(width, parent, new TextBoxFormatOptions()) {}
    public TextColumnContainer(int width, AContainer1 parent, TextBoxFormatOptions formatOptions) : base(width, parent)
    {
        TextBox = new TextBox(Width, Height, formatOptions);
    }

    public override void Render(int x, int y, int maxWidth, int maxHeight)
    {
        throw new NotImplementedException();
    }
}