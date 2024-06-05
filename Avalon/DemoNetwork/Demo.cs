namespace DemoNetwork;

class Demo : Any
{
    public bool Execute()
    {
        ThreadNetworkState state;
        state = new ThreadNetworkState();
        state.Init();

        state.Execute();
        return true;
    }
}