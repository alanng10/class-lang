namespace Demo;

class NetworkPeerCaseState : State
{
    public ThreadNetworkServerState ServerState { get; set; }
    private int Status { get; set; }

    public override bool Execute()
    {
        NetworkCaseList caseList;
        caseList = this.ServerState.Demo.NetworkCaseList;

        Network network;
        network = this.ServerState.Demo.Peer;

        if (network.Case == caseList.Connected)
        {
        }

        if (network.Case == caseList.Unconnected)
        {
        }

        return true;
    }
}