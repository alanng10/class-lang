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

        this.Intern = new ConsoleIntern();
        this.Intern.Init();

        ConsoleOut ka;
        ka = new ConsoleOut();
        ka.Init();
        ka.Intern = this.Intern;
        ka.Stream = 0;
        this.Out = ka;

        ConsoleOut kb;
        kb = new ConsoleOut();
        kb.Init();
        kb.Intern = this.Intern;
        kb.Stream = 1;
        this.Err = kb;

        ConsoleInn kc;
        kc = new ConsoleInn();
        kc.Init();
        kc.Intern = this.Intern;
        this.Inn = kc;

        return true;
    }

    public virtual Out Out { get; set; }
    public virtual Out Err { get; set; }
    public virtual Inn Inn { get; set; }
    private ConsoleIntern Intern { get; set; }
}