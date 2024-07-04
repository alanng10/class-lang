namespace Demo;

class NetworkPeerStatusState : State
{
    public ThreadNetworkHostState ServerState { get; set; }
    private int Status { get; set; }

    public override bool Execute()
    {
        bool b;
        b = this.ExecuteAll();
        if (!b)
        {
            this.ServerState.ExitNetwork(this.Status);
        }
        return true;
    }

    private bool ExecuteAll()
    {
        NetworkStatusList statusList;
        statusList = this.ServerState.Demo.NetworkStatusList;

        Network network;
        network = this.ServerState.Demo.Peer;

        if (!(network.Status == statusList.NoError))
        {
            this.Status = 160;
            return false;
        }

        return true;
    }
}