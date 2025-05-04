namespace Demo;

public class NetworkA : NetworkNetwork
{
    public override bool Init()
    {
        base.Init();

        this.TextInfra = TextInfra.This;
        this.StringComp = StringComp.This;


        return true;
    }

    public Data Data { get; set; }
    public Range Range { get; set; }

    public virtual ThreadNetworkState ThreadState { get; set; }

    public virtual long StatusCode { get; set; }
    public virtual long Stage { get; set; }

    protected virtual TextInfra TextInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }

    public override bool CaseEvent()
    {
        NetworkCaseList caseList;
        caseList = this.ThreadState.NetworkCaseList;

        if (this.Case == caseList.Connected)
        {
            Data data;
            data = this.Data;

            Range range;
            range = this.Range;

            data.Set(0, 58);

            range.Count = 1;

            this.Stream.Write(data, range);
        }

        if (this.Case == caseList.Unconnected)
        {
        }

        return true;
    }

    public override bool StatusEvent()
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
            this.StatusCode = 4000 + this.Status.Index;
            return false;
        }

        return true;
    }

    public override bool DataEvent()
    {
        bool b;
        b = this.DataExecute();
        if (!b)
        {
            this.ThreadState.ExitNetwork(this.StatusCode);
        }
        return true;
    }

    private bool DataExecute()
    {

    }

    private String S(string o)
    {
        return this.TextInfra.S(o);
    }
}