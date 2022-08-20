abstract class ARowContainer : AContainer1
{
    protected AContainer1 parent;
    public override AContainer1 Parent => parent;

    int height;

    public override int Width => Parent.Width;
    public override int Height => height;

    public ARowContainer(int height, AContainer1 parent)
    {
        this.height = height;
        this.parent = Parent;
    }
}
