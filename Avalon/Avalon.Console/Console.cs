namespace Avalon.Console;

public class Console : Any
{
    public static Console This { get; } = ShareCreate();

    private static Console ShareCreate()
    {
        Console share;
        share = new Console();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();

        ConsoleOut ka;
        ka = new ConsoleOut();
        ka.Init();
        ka.Stream = 0;
        this.Out = ka;

        ConsoleOut kb;
        kb = new ConsoleOut();
        kb.Init();
        kb.Stream = 1;
        this.Err = kb;

        ConsoleInn kc;
        kc = new ConsoleInn();
        kc.Init();
        this.Inn = kc;

        return true;
    }

    public virtual Out Out { get; set; }
    public virtual Out Err { get; set; }
    public virtual Inn Inn { get; set; }
}