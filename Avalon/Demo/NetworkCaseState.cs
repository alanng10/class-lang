namespace Demo;

public class NetworkCaseState : State
{
    public ThreadNetworkState NetworkState { get; set; }
    private int Status { get; set; }

    public override bool Execute()
    {
        NetworkCaseList caseList;
        caseList = this.NetworkState.NetworkCaseList;

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
        }

        if (network.Case == caseList.Unconnected)
        {
        }

        return true;
    }
}