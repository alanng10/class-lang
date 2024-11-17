class ThreadNetworkHostState : StateA
{
    field prusate Network Peer { get { return data; } set { data : value; } }

    maide prusate Bool Execute()
    {
        var NetworkPortKindList portKindList;
        portKindList : share NetworkPortKindList;

        var NetworkPort port;
        port : new NetworkPort;
        port.Init();
        port.Kind : portKindList.LocalHost;
        port.Host = 59843
    }
}