namespace Demo;

class NetworkOpenElapseState : State
{
    public ThreadNetworkState ThreadNetworkState { get; set; }
    
    public override bool Execute()
    {
        this.ThreadNetworkState.Demo.Server.Open();
        return true;
    }
}