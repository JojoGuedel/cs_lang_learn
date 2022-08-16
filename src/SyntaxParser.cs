enum SyntaxTokenKind
{
    InvalidExpression,
    CharExpression,

    DashSeparator,
    DotSeparator,

    WhiteSpaceSeparator,
    CommaSeparator,
    SlashSeparator,
    SemiColonSeparator,

    LeftParen,
    RightParen,
    LeftSquareParen,
    RightSquareParen,
    LeftCurlyParen,
    RightCurlyParen,
    LeftAngleParen,
    RightAngleParen,

}

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
}

class SyntaxToken
{
    public SyntaxTokenKind Kind { get; private set; }
    public TextSpan Span { get; private set; }

    public SyntaxToken(SyntaxTokenKind kind, TextSpan span)
    {
        Kind = kind;
        Span = span;
    }
}

class SyntaxParser
{
    string Text;

    List<SyntaxToken> Tokens;

    int Pos;
    int End;

    public SyntaxParser(string text)
    {
        Text = text;
        End = text.Length;

        Tokens = new List<SyntaxToken>();
    }

    public void Lex()
    {
        Pos = 0;

        while (true)
        {
            int start = Pos;
            char current = Text[Pos];

            if (current == '\0')
            {
                break;
            }
            Tokens.Add(new SyntaxToken(SyntaxTokenKind.WordExpression, TextSpan.FromText(Text, start, Pos - start)));
            }

            // separators
            else if (char.IsWhiteSpace(current))
            {
                Tokens.Add(new SyntaxToken(SyntaxTokenKind.WhiteSpaceSeparator, new TextSpan(Next(), start, 1)));
            }
            else if (current == ',')
            {
                Tokens.Add(new SyntaxToken(SyntaxTokenKind.CommaSeparator, new TextSpan(Next(), start, 1)));
            }
            else if (current == '/')
            {
                Tokens.Add(new SyntaxToken(SyntaxTokenKind.SlashSeparator, new TextSpan(Next(), start, 1)));
            }
            else if (current == ';')
            {
                Tokens.Add(new SyntaxToken(SyntaxTokenKind.SemiColonSeparator, new TextSpan(Next(), start, 1)));
            }

            else
            {

            }
        }
    }

    char Peek(int offset = 0)
    {
        if (Pos + offset >= End)
            return '\0';

        return Text[Pos + offset];
    }

    char Next(int increment = 1)
    {
        if (Pos + increment >= End)
            return '\0';

        char current = Text[Pos];
        Pos += increment;
        return current;
    }

}