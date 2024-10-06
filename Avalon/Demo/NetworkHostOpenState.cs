namespace Demo;

class NetworkHostOpenState : State
{
    public ThreadNetworkHostState ThreadNetworkHostState { get; set; }

    public override bool Execute()
    {
        this.ThreadNetworkHostState.Demo.Host.Open();

        this.ThreadNetworkHostState.TimeEvent.Stop();
        return true;
    }
}