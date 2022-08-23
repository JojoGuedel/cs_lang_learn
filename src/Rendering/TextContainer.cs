using System;

class TextContainer : AContainer
{
    int width;
    int height;

    public override int Width => width;
    public override int Height => height;

    AContainer parent;
    public override AContainer Parent => parent;

    TextBox textBox;
    public TextBox TextBox => textBox;


    public TextContainer(AContainer parent, int width, int height)
    {
        this.parent = parent;

        this.width = width;
        this.height = height;

        textBox = new TextBox(this.width, this.height, new TextBoxFormatOptions());
    }

    public override void Render(int x, int y, int maxWidth, int maxHeight)
    {   
        TextLine[] lines = textBox.Lines;

        for (int _y = 0; _y < lines.Length && y + y < maxHeight; _y++)
        {
            Console.SetCursorPosition(x, _y);
            Console.Write(lines[_y].Text);
        }
    }
}