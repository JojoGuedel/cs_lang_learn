abstract class AColumnContainer : AContainer1
{
    protected AContainer1 parent;
    public override AContainer1 Parent => parent;

    int width;

    public override int Width => width;
    public override int Height => Parent.Height;

    public AColumnContainer(int width, AContainer1 parent)
    {
        this.width = width;
        this.parent = parent;
    }
}