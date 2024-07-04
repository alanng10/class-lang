namespace Demo;

class NetworkHostOpenState : State
{
    public ThreadNetworkHostState ThreadNetworkServerState { get; set; }
    
    public override bool Execute()
    {
        this.ThreadNetworkServerState.Demo.Host.Open();
        return true;
    }
}