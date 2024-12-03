class NetworkHostA : NetworkHost
{
    field prusate ThreadNetworkHostState ThreadState { get { return data; } set { data : value; } }

    maide prusate Bool NewPeer()
    {
        inf (~(this.ThreadState.Peer = null))
        {
            share Console.Out.Write("Network Peer is more one\n");
            return false;
        }

        var Network network;
        network : this.OpenPeer();

        this.ThreadState.Peer : network;
        return true;
    }

    maide precate Network CreatePeer(var Any peer)
    {
        var NetworkB a;
        a : new NetworkB;
        a.HostPeer : peer;
        a.Init();
        a.ThreadState : this.ThreadState;
        return a;
    }
}