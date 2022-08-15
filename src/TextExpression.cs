

class TextExpression2 {
    string expression = string.Empty;
    Language langauge = Language.unknown;

    public TextExpression2(string expression, Language language = Language.unknown) {
        this.expression = expression;
        this.langauge = language;
    }
}
