namespace Demo;

class NetworkPeer : NetworkNetwork
{
    public override bool Init()
    {
        this.Data = new Data();
        this.Data.Count = 10;
        this.Data.Init();

        this.Range = new Range();
        this.Range.Init();
        return true;
    }

    public Demo Demo { get; set; }
    public ThreadNetworkHostState ThreadState { get; set; }

    private Data Data { get; set; }
    private Range Range { get; set; }
    private long Stage { get; set; }
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