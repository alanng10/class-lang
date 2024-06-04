namespace Demo;

class NetworkOpenState : State
{
    public ThreadNetworkState ThreadNetworkState { get; set; }
    
    public override bool Execute()
    {
        this.ThreadNetworkState.Network.Open();
        return true;
    }
}