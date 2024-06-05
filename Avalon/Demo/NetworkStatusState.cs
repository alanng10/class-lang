namespace Demo;

class NetworkStatusState : State
{
    public ThreadNetworkState NetworkState { get; set; }
    private int Status { get; set; }

    public override bool Execute()
    {
        bool b;
        b = this.ExecuteAll();
        if (!b)
        {
            this.NetworkState.ExitNetwork(this.Status);
        }
        return true;
    }

    private bool ExecuteAll()
    {
        NetworkStatusList statusList;
        statusList = this.NetworkState.Demo.NetworkStatusList;

        Network network;
        network = this.NetworkState.Network;

        if (!(network.Status == statusList.NoError))
        {
            this.Status = 130;
            return false;
        }

        return true;
    }
}