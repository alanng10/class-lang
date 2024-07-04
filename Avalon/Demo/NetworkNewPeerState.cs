namespace Demo;

class NetworkNewPeerState : State
{
    public Demo Demo { get; set; }
    public ThreadNetworkHostState HostState { get; set; }
    
    public override bool Execute()
    {
        if (!(this.Demo.Peer == null))
        {
            Console.This.Err.Write("Network Peer is more one\n");
            return false;
        }

        Network network;
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