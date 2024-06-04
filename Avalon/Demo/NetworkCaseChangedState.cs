namespace Demo;

class NetworkCaseChangedState : State
{
    public ThreadNetworkState NetworkState { get; set; }
    private int Status { get; set; }

    public override bool Execute()
    {
        bool b;
        b = this.ExecuteAll();
        if (!b)
        {
            Console.This.Err.Write("Network Status: " + this.Status + "\n");

            NetworkReadyState ka;
            ka = this.NetworkState.ReadyState;
            ka.ExitNetwork(400);
        }
        return true;
    }

    private bool ExecuteAll()
    {
        NetworkCaseList caseList;
        caseList = this.NetworkState.Demo.NetworkCaseList;

        Network network;
        network = this.NetworkState.Network;
        
        if (network.Case == caseList.Connected)
        {
            NetworkReadyState ka;
            ka = this.NetworkState.ReadyState;

            Data data;
            data = ka.Data;

            DataRange range;
            range = ka.Range;

            data.Set(0, 58);

            range.Count = 1;

            network.Stream.Write(data, range);

            if (!ka.CheckStatus())
            {
                this.Status = 15;
                return false;
            }
        }

        return true;
    }
}