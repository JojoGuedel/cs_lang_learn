class SyntaxParser
{
    string Text;

    public List<SyntaxToken> Tokens { get; private set; }

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
            char current = Peek();

            if (current == '\0')
            {
                break;
            }

            // separators
            else if (char.IsWhiteSpace(current))
            {
                Tokens.Add(new SyntaxToken(SyntaxTokenKind.WhiteSpaceSeparator, new TextSpan(Next(), start, Pos - start)));
            }
            else if (current == ',')
            {
                Tokens.Add(new SyntaxToken(SyntaxTokenKind.CommaSeparator, new TextSpan(Next(), start, Pos - start)));
            }
            else if (current == '/')
            {
                Tokens.Add(new SyntaxToken(SyntaxTokenKind.SlashSeparator, new TextSpan(Next(), start, Pos - start)));
            }
            else if (current == ';')
            {
                Tokens.Add(new SyntaxToken(SyntaxTokenKind.SemiColonSeparator, new TextSpan(Next(), start, Pos - start)));
            }

            else
            {
                Tokens.Add(new SyntaxToken(SyntaxTokenKind.CharExpression, new TextSpan(Next(), start, Pos - start)));
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
        char current = Peek();
        Pos += increment;
        return current;
    }

}