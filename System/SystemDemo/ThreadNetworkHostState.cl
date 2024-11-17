class ThreadNetworkHostState : StateA
{
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