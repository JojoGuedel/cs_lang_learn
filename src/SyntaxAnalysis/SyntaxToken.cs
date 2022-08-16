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
