namespace Demo;

class NetworkServerOpenState : State
{
    public ThreadNetworkServerState ThreadNetworkServerState { get; set; }
    
    public override bool Execute()
    {
        this.ThreadNetworkServerState.Demo.Server.Open();
        return true;
    }
}