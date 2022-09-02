class PracticeExpressionModel
{
    public int Visited { get; set; }
    public int Correct { get; set; }
    public string Content { get; set; }
    public string Language { get; set; }

    public PracticeExpressionModel() : this("") { }
    public PracticeExpressionModel(string content)
    {
        Visited = 0;
        Correct = 0;
        Content = content;
        Language = "unknown";
    }
}
