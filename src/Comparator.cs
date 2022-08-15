enum ComparisonState
{
    EQUAL = 0,
    SIMILAR = 1,
    DIFFERENT = 2,
}

class CharExpression
{
    public char Char { get; private set; }

    public CharExpression(char c)
    {
        Char = c;
    }

    public char[] GetSimilar()
    {
        switch (Char)
        {
            case 'a':
            case 'ä':
            case 'à':
                return new char[] { 'a', 'ä', 'à' };
            case 'b':
                return new char[] { 'b' };
            case 'c':
            case 'ç':
                return new char[] { 'c', 'ç' };
            case 'e':
            case 'é':
            case 'è':
            case 'ê':
                return new char[] { 'e', 'é', 'è', 'ê' };
            case 'i':
            case 'î':
            case 'ï':
                return new char[] { 'i', 'î', 'ï' };
            case 'o':
            case 'ö':
            case 'ô':
                return new char[] { 'o', 'ö', 'ô' };
            case 'u':
            case 'ü':
            case 'û':
                return new char[] { 'u', 'ü', 'û' };
            default:
                return new char[] { Char };
        }
    }

    public bool IsEqual(CharExpression other)
    {
        return Char.Equals(other.Char);
    }

    public bool IsSimilar(CharExpression other)
    {
        foreach (char s in other.GetSimilar())
            if (Char == s)
                return true;

        return false;
    }
}

class WordExpression
{
    public List<CharExpression> Word { get; private set; }
    public bool IsOptional { get; private set; }

    public WordExpression(string expression, bool isOptional = false)
    {
        Word = new List<CharExpression>();

        for (int i = 0; i < expression.Length; i++)
            Word.Add(new CharExpression(expression[i]));
        
        IsOptional = isOptional;
    }

    public WordExpression(List<CharExpression> expression, bool isOptional = false)
    {
        Word = expression;
        IsOptional = isOptional;
    }
}