namespace Demo;

class NetworkNewPeerState : State
{
    public Demo Demo { get; set; }
    
    public override bool Execute()
    {
        this.Demo.Peer = this.Demo.Server.NextPendingPeer();
        return true;
    }
}