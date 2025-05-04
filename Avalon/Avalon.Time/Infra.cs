namespace Avalon.Time;

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
        TimeEventElapseMaide maideA;
        maideA = new TimeEventElapseMaide(Event.InternElapse);
        this.TimeEventElapseMaideAddress = new MaideAddress();
        this.TimeEventElapseMaideAddress.Delegate = maideA;
        this.TimeEventElapseMaideAddress.Init();
        return true;
    }

    public virtual MaideAddress TimeEventElapseMaideAddress { get; set; }
}