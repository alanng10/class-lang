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

        ConsoleOut oa;
        oa = new ConsoleOut();
        oa.Init();
        oa.Intern = this.Intern;
        oa.Stream = 0;
        this.Out = oa;

        ConsoleOut ob;
        ob = new ConsoleOut();
        ob.Init();
        ob.Intern = this.Intern;
        ob.Stream = 1;
        this.Err = ob;

        ConsoleIon oc;
        oc = new ConsoleIon();
        oc.Init();
        oc.Intern = this.Intern;
        this.Ion = oc;

        return true;
    }

    public virtual bool Final()
    {
        this.Intern.Final();
        return true;
    }

    private ConsoleIntern Intern { get; set; }

    public virtual Out Out { get; set; }

    public virtual Out Err { get; set; }

    public virtual Ion Ion { get; set; }
}