namespace Demo;

public class Network : NetworkNetwork
{
    public virtual ThreadNetworkState ThreadState { get; set; }

    protected override bool CaseEvent()
    {
        NetworkCaseList caseList;
        caseList = this.ThreadState.NetworkCaseList;

        Network network;
        network = this.ThreadState.Network;

        if (network.Case == caseList.Connected)
        {
            NetworkReadyState ka;
            ka = this.ThreadState.ReadyState;

            Data data;
            data = ka.Data;

            Range range;
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