namespace Demo;

class ThreadNetworkState : ThreadExecuteState
{
    public Demo Demo { get; set; }
    public Network Network { get; set; }

    public override bool Execute()
    {
        string hostName;
        hostName = "localhost";
        int serverPort;
        serverPort = 50400;

        Network network;
        network = new Network();
        network.Init();

        network.HostName = hostName;
        network.ServerPort = serverPort;

        this.Network = network;

        network.Open();

        ThreadCurrent current;
        current = new ThreadCurrent();
        current.Init();

        ThreadThread thread;
        thread = current.Thread;

        thread.ExecuteEventLoop();
        return true;
    }
}