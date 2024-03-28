namespace Avalon.Console;

public class Console : Any
{
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

        ConsoleIn oc;
        oc = new ConsoleIn();
        oc.Init();
        oc.Intern = this.Intern;
        this.In = oc;

        return true;
    }

    private ConsoleIntern Intern { get; set; }

    public virtual Out Out { get; set; }

    public virtual Out Err { get; set; }

    public virtual In In { get; set; }
}