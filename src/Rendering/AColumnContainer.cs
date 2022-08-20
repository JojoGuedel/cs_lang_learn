abstract class AColumnContainer : AContainer
{
    protected AContainer parent;
    public override AContainer Parent => parent;

    int width;

    public override int Width => width;
    public override int Height => Parent.Height;

    public AColumnContainer(int width, AContainer parent)
    {
        this.width = width;
        this.parent = parent;
    }
}