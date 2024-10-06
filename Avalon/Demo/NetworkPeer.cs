namespace Demo;

class NetworkPeer : NetworkNetwork
{
    public ThreadNetworkHostState ThreadState { get; set; }
    private long StatusCode { get; set; }

    public override bool StatusEvent()
    {
        bool b;
        b = this.StatusExecute();
        if (!b)
        {
            this.ThreadState.ExitNetwork(this.StatusCode);
        }
        return true;
    }

    private bool StatusExecute()
    {
        NetworkStatusList statusList;
        statusList = this.ThreadState.Demo.NetworkStatusList;

        if (!(this.Status == statusList.NoError))
        {
            this.StatusCode = 160;
            return false;
        }

        return true;
    }
}