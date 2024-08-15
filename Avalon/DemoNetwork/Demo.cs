namespace DemoNetwork;

class Demo : Any
{
    private StringValue StringValue { get; set; }
    
    public bool Execute()
    {
        this.StringValue = StringValue.This;

        Console.This.Out.Write(this.S("DemoNetwork Start\n"));

        ThreadNetworkState state;
        state = new ThreadNetworkState();
        state.Init();

        state.Execute();

        Console.This.Out.Write(this.S("DemoNetwork End\n"));
        return true;
    }

    public virtual String S(string o)
    {
        return this.StringValue.Execute(o);
    }
}