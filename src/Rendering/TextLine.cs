using System;
using System.Text;

class TextLine
{
    int width;
    int cursorPos;

    StringBuilder text;
    public string Text { get => Align(); }

    TextWrap TextWrap;
    HorizontalTextAlign TextAlign;

    public TextLine(int width, TextWrap wrap = TextWrap.DASH, HorizontalTextAlign align = HorizontalTextAlign.LEFT) 
    {
        this.width = width;
        cursorPos = 0;

        TextWrap = wrap;
        TextAlign = align;

        text = new StringBuilder("".PadLeft(width));
    }

    public string Write(string word, bool whitespace = true)
    {
        // whitespace
        if (whitespace && cursorPos < width && cursorPos != 0)
            cursorPos++;

        if (cursorPos >= width)
            return word;

        if (width - cursorPos < 3 && word.Length > 2)
            return word;

        if (width - cursorPos < word.Length && TextWrap == TextWrap.FULL)
            return word;
        
        if (width - cursorPos < 4 && word.Length > 3 && TextWrap == TextWrap.DOTS)
        {
            WriteDots();
            return word;
        }

        int i;
        for (i = 0; cursorPos < width && i < word.Length; cursorPos++, i++)
            text[cursorPos] = word[i];

        // line wraping
        if (i != word.Length)
        {
            switch (TextWrap)
            {
                case TextWrap.DASH:
                    i = Math.Max(0, i - 1);
                    text[text.Length - 1] = '-';
                    break;
                case TextWrap.DOTS:
                    i = Math.Max(0, i - 3);
                    WriteDots();
                    break;
                case TextWrap.HIDDEN:
                    return "";
            }
        }

        return word.Substring(i);
    }

    public string Align()
    {
        int start = 0; 

        switch(TextAlign)
        {
            case HorizontalTextAlign.CENTER:
                start = (width - cursorPos) / 2;
                break;
            case HorizontalTextAlign.RIGHT:
                start = width - cursorPos;
                break;
        }

        StringBuilder ret = new StringBuilder("".PadLeft(width));
        for (int i = 0; i < cursorPos; i++)
            ret[start + i] = text[i];

        return ret.ToString();
    }

    public void WriteDots() 
    {
        for (cursorPos = width - 3; cursorPos < width; cursorPos++)
            text[cursorPos] = '.';
    }
}
