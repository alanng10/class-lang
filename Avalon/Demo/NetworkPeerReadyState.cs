namespace Demo;

class NetworkPeerReadyState : State
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
    public ThreadNetworkHostState HostState { get; set; }

    private Data Data { get; set; }
    private Range Range { get; set; }
    private long Case { get; set; }
    private long Status { get; set; }


}