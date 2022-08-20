using System;

class TextBox
{
    public int Width { get; private set; }
    public int Height { get; private set; }

    TextBoxFormatOptions formatOptions;

    int cursorPos;

    TextLine[] lines;
    public TextLine[] Lines { get => Align(); }

    public TextBox(int width, int height, TextBoxFormatOptions formatOptions)
    {
        Width = width;
        Height = height;

        cursorPos = 0;

        this.formatOptions = formatOptions;

        lines = new TextLine[Height];
        for (int i = 0; i < lines.Length; i++)
            lines[i] = new TextLine(
                            Width,
                            i == lines.Length -1? TextWrap.DOTS : formatOptions.TextWrap,
                            formatOptions.HorizontalAlign);
    }

    public string Write(string word, bool whitespace = true) 
    {
        while (cursorPos < Height && word != "")
        {
            word = lines[cursorPos].Write(word, whitespace);
            
            if (word != "")
                cursorPos++;
        }

        return word;
    }

    public TextLine[] Align()
    {
        int start = 0;
        switch (formatOptions.VerticalAlign)
        {
            case VerticalTextAlign.CENTER:
                start = (Height - cursorPos) / 2;
                break;
            case VerticalTextAlign.BOTTOM:
                start = (Height - cursorPos);
                break;
        }

        TextLine[] ret = new TextLine[Height];
        for (int i = 0; i < lines.Length; i++)
            ret[i] = new TextLine(
                            Width,
                            i == lines.Length -1? TextWrap.DOTS : formatOptions.TextWrap,
                            formatOptions.HorizontalAlign);

        for (int i = 0; i < cursorPos + 1; i++)
            ret[start + i] = lines[i]; 

        return ret;
    }
}
