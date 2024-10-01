namespace Avalon.Frame;

class Infra : Any
{
    public static Infra This { get; } = ShareCreate();

    private static Infra ShareCreate()
    {
        Infra share;
        share = new Infra();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();

        FrameTypeMaide maideA;
        maideA = new FrameTypeMaide(Frame.InternType);
        this.FrameTypeMaideAddress = new MaideAddress();
        this.FrameTypeMaideAddress.Delegate = maideA;
        this.FrameTypeMaideAddress.Init();
        FrameDrawMaide maideB;
        maideB = new FrameDrawMaide(Frame.InternDraw);
        this.FrameDrawMaideAddress = new MaideAddress();
        this.FrameDrawMaideAddress.Delegate = maideB;
        this.FrameDrawMaideAddress.Init();
        return true;
    }

    internal virtual MaideAddress FrameTypeMaideAddress { get; set; }
    internal virtual MaideAddress FrameDrawMaideAddress { get; set; }
}