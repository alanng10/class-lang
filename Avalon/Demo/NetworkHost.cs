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

        NetworkPeerReadyState state;
        state = new NetworkPeerReadyState();
        state.Demo = this.Demo;
        state.HostState = this.HostState;
        state.Init();

        NetworkPeerStatusState stateA;
        stateA = new NetworkPeerStatusState();
        stateA.HostState = this.HostState;
        stateA.Init();

        network.StatusChangeState = stateA;

        network.ReadyReadState = state;
        return true;
    }
}