class PracticeCardModel
{
    public PracticeExpressionModel Expr1 { get; set; }
    public PracticeExpressionModel Expr2 { get; set; }

    public PracticeCardModel()
    {
        Expr1 = new PracticeExpressionModel();
        Expr2 = new PracticeExpressionModel();
    }

    public PracticeCardModel(string content1, string content2)
    {
        Expr1 = new PracticeExpressionModel(content1);
        Expr2 = new PracticeExpressionModel(content2);
    }

    public PracticeCardModel(string content1, string lang1, string content2, string lang2)
    {
        Expr1 = new PracticeExpressionModel(content1);
        Expr1.Language = lang1;
        Expr2 = new PracticeExpressionModel(content2);
        Expr2.Language = lang2;
    }
}
