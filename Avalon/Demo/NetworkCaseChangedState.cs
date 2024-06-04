namespace Demo;

class NetworkCaseChangedState : State
{
    public ThreadNetworkState NetworkState { get; set; }
    
    public override bool Execute()
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
                Console.This.Err.Write("Network Status: " + 15 + "\n");
                return false;
            }
        }

        return true;
    }
}