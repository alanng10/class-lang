namespace Demo;

class NetworkPeerReadyState : State
{
    public Demo Demo { get; set; }

    public override bool Execute()
    {
        Network peer;
        peer = this.Demo.Peer;

        long readyCount;
        readyCount = peer.ReadyCount;
        return true;
    }
}