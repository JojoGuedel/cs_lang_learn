struct TextBoxFormatOptions
{
    public HorizontalTextAlign HorizontalAlign { get; private set; }
    public VerticalTextAlign VerticalAlign { get; private set; }

    public TextWrap TextWrap { get; private set; }

    public TextBoxFormatOptions()
    {
        HorizontalAlign = HorizontalTextAlign.LEFT;
        VerticalAlign = VerticalTextAlign.TOP;
        TextWrap = TextWrap.WRAP;
    }
}
