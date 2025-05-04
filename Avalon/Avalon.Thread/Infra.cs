namespace Avalon.Thread;

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
        ThreadExecuteMaide maide;
        maide = new ThreadExecuteMaide(Thread.InternExecute);
        this.ThreadExecuteMaideAddress = new MaideAddress();
        this.ThreadExecuteMaideAddress.Delegate = maide;
        this.ThreadExecuteMaideAddress.Init();
        return true;
    }

    public virtual MaideAddress ThreadExecuteMaideAddress { get; set; }
}