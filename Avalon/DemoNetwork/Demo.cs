namespace DemoNetwork;

class Demo : Any
{
    public bool Execute()
    {
        Console.This.Out.Write("DemoNetwork Start\n");

        ThreadNetworkState state;
        state = new ThreadNetworkState();
        state.Init();

        state.Execute();

        Console.This.Out.Write("DemoNetwork End\n");
        return true;
    }
}