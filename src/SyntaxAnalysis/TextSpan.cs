class TextSpan
{
    public string Text { get; private set; }

    public int Start { get; private set; }
    public int Length { get; private set; }

    public TextSpan(string span, int start, int length)
    {
        Text = span;
        Start = start;
        Length = length;
    }

    public TextSpan(char span, int start, int length)
    {
        Text = span.ToString();
        Start = start;
        Length = length;
    }

    public static TextSpan FromText(string text, int start, int length)
    {
        string span = text.Substring(start, length);
        return new TextSpan(span, start, length);
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}
