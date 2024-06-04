namespace Demo;

class NetworkNewPeerState : State
{
    public Demo Demo { get; set; }
    
    public override bool Execute()
    {
        if (!(this.Demo.Peer == null))
        {
            Console.This.Err.Write("Network Peer is more one\n");
            return false;
        }

        this.Demo.Peer = this.Demo.Server.NextPendingPeer();

        NetworkPeerReadyState state;
        state = new NetworkPeerReadyState();
        state.Demo = this.Demo;
        state.Init();

        this.Demo.Peer.ReadyReadState = state;
        return true;
    }
}