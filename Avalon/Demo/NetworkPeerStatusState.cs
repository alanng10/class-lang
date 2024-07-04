namespace Demo;

class NetworkPeerStatusState : State
{
    public ThreadNetworkHostState HostState { get; set; }
    private int Status { get; set; }

    public override bool Execute()
    {
        bool b;
        b = this.ExecuteAll();
        if (!b)
        {
            this.HostState.ExitNetwork(this.Status);
        }
        return true;
    }

    private bool ExecuteAll()
    {
        NetworkStatusList statusList;
        statusList = this.HostState.Demo.NetworkStatusList;

        Network network;
        network = this.HostState.Demo.Peer;

        if (!(network.Status == statusList.NoError))
        {
            this.Status = 160;
            return false;
        }

        return true;
    }
}