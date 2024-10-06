namespace Demo;

public class Network : NetworkNetwork
{
    public virtual ThreadNetworkState ThreadState { get; set; }

    public virtual long StatusCode { get; set; }

    protected override bool CaseEvent()
    {
        NetworkCaseList caseList;
        caseList = this.ThreadState.NetworkCaseList;

        if (this.Case == caseList.Connected)
        {
            NetworkReadyState ka;
            ka = this.ThreadState.ReadyState;

            Data data;
            data = ka.Data;

            Range range;
            range = ka.Range;

            data.Set(0, 58);

            range.Count = 1;

            this.Stream.Write(data, range);
        }

        if (this.Case == caseList.Unconnected)
        {
        }

        return true;
    }

    protected override bool StatusEvent()
    {
        bool b;
        b = this.StatusExecute();
        if (!b)
        {
            this.ThreadState.ExitNetwork(this.StatusCode);
        }
        return true;
    }

    private bool StatusExecute()
    {
        NetworkStatusList statusList;
        statusList = this.ThreadState.NetworkStatusList;

        if (!(this.Status == statusList.NoError))
        {
            this.StatusCode = 130;
            return false;
        }

        return true;
    }
}