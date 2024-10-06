namespace Demo;

class NetworkHostA : NetworkHost
{
    public Demo Demo { get; set; }
    public ThreadNetworkHostState HostState { get; set; }

    public override bool PeerEvent()
    {
        if (!(this.Demo.Peer == null))
        {
            Console.This.Err.Write(this.Demo.S("Network Peer is more one\n"));
            return false;
        }

        NetworkNetwork network;
        network = this.Demo.Host.OpenPeer();

        this.Demo.Peer = network;
        return true;
    }

    protected override NetworkNetwork CreatePeer(ulong peer)
    {
        NetworkB a;
        a = new NetworkB();
        a.HostPeer = peer;
        a.Init();
        return a;
    }
}