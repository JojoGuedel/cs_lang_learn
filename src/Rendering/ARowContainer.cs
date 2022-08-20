abstract class ARowContainer : AContainer
{
    protected AContainer parent;
    public override AContainer Parent => parent;

    int height;

    public override int Width => Parent.Width;
    public override int Height => height;

    public ARowContainer(int height, AContainer parent)
    {
        this.parent = Parent;
        this.height = height;
    }
}
