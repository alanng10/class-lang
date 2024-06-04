namespace Demo;

class NetworkCaseChangedState : State
{
    public ThreadNetworkState NetworkState { get; set; }
    
    public override bool Execute()
    {
        NetworkCaseList caseList;
        caseList = this.NetworkState.Demo.NetworkCaseList;

        Network network;
        network = this.NetworkState.Network;
        
        if (network.Case == caseList.Connected)
        {
            
        } 

        return true;
    }
}