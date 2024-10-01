namespace Avalon.Network;

public class Network : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
        this.NetworkInfra = Infra.This;
        this.NetworkCaseList = CaseList.This;
        this.NetworkStatusList = StatusList.This;
        this.InternHandle = new Handle();
        this.InternHandle.Any = this;
        this.InternHandle.Init();

        MaideAddress oa;
        oa = this.NetworkInfra.NetworkStatusChangeMaideAddress;
        MaideAddress ob;
        ob = this.NetworkInfra.NetworkCaseChangeMaideAddress;
        MaideAddress oc;
        oc = this.NetworkInfra.NetworkReadyReadMaideAddress;
        ulong arg;
        arg = this.InternHandle.ULong();
        this.InternStatusChangeState = this.InternInfra.StateCreate(oa, arg);
        this.InternCaseChangeState = this.InternInfra.StateCreate(ob, arg);
        this.InternReadyReadState = this.InternInfra.StateCreate(oc, arg);

        bool b;
        b = (this.HostPeer == 0);
        if (b)
        {
            this.Intern = Extern.Network_New();
            Extern.Network_Init(this.Intern);
        }
        if (!b)
        {
            this.Intern = this.HostPeer;

            ulong streamU;
            streamU = Extern.Network_StreamGet(this.Intern);
            this.DataStream = this.StreamCreateIntern(streamU);
            this.Stream = this.DataStream;
        }

        Extern.Network_StatusChangeStateSet(this.Intern, this.InternStatusChangeState);
        Extern.Network_CaseChangeStateSet(this.Intern, this.InternCaseChangeState);
        Extern.Network_ReadyReadStateSet(this.Intern, this.InternReadyReadState);
        return true;
    }

    public virtual bool Final()
    {
        Extern.Network_ReadyReadStateSet(this.Intern, 0);
        Extern.Network_CaseChangeStateSet(this.Intern, 0);
        Extern.Network_StatusChangeStateSet(this.Intern, 0);

        bool b;
        b = (this.HostPeer == 0);
        if (b)
        {
            Extern.Network_Final(this.Intern);
            Extern.Network_Delete(this.Intern);
        }
        if (!b)
        {
            this.DataStream.Final();
            this.Stream = null;
        }

        this.InternInfra.StateDelete(this.InternReadyReadState);
        this.InternInfra.StateDelete(this.InternCaseChangeState);
        this.InternInfra.StateDelete(this.InternStatusChangeState);

        this.InternHandle.Final();
        return true;
    }

    public virtual ulong HostPeer { get; set; }
    public virtual String HostName { get; set; }
    public virtual long HostPort { get; set; }
    public virtual StreamStream Stream { get; set; }
    protected virtual StreamStream DataStream { get; set; }
    public virtual bool LoadingOpen { get; set; }

    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    private Infra NetworkInfra { get; set; }
    protected virtual CaseList NetworkCaseList { get; set; }
    protected virtual StatusList NetworkStatusList { get; set; }

    private ulong Intern { get; set; }
    private ulong InternReadyReadState { get; set; }
    private ulong InternCaseChangeState { get; set; }
    private ulong InternStatusChangeState { get; set; }
    private Handle InternHandle { get; set; }
    private ulong InternHostName { get; set; }

    public virtual Status Status
    {
        get
        {
            ulong u;
            u = Extern.Network_StatusGet(this.Intern);
            long o;
            o = (long)u;
            Status a;
            a = this.NetworkStatusList.Get(o);
            return a;
        }
        set
        {
        }
    }

    public virtual Case Case
    {
        get
        {
            ulong u;
            u = Extern.Network_CaseGet(this.Intern);
            if (u == 0)
            {
                return null;
            }
            u = u - 1;
            long o;
            o = (long)u;
            Case a;
            a = this.NetworkCaseList.Get(o);
            return a;
        }
        set
        {
        }
    }

    public virtual long ReadyCount
    {
        get
        {
            ulong u;
            u = Extern.Network_ReadyCountGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
        }
    }

    public virtual bool Open()
    {
        if (!(this.Stream == null))
        {
            return true;
        }
        if (this.LoadingOpen)
        {
            return true;
        }

        this.LoadingOpen = true;

        this.InternHostName = this.InternInfra.StringCreate(this.HostName.Value);
        ulong hostPortU;
        hostPortU = (ulong)this.HostPort;
        this.DataStream = this.StreamCreate();

        Extern.Network_HostNameSet(this.Intern, this.InternHostName);
        Extern.Network_HostPortSet(this.Intern, hostPortU);
        Extern.Network_StreamSet(this.Intern, this.DataStream.Ident);
        Extern.Network_Open(this.Intern);
        return true;
    }

    public virtual bool Close()
    {
        this.LoadingOpen = false;
        
        Extern.Network_Close(this.Intern);

        Extern.Network_StreamSet(this.Intern, 0);
        Extern.Network_HostPortSet(this.Intern, 0);
        Extern.Network_HostNameSet(this.Intern, 0);

        this.DataStream.Final();
        this.DataStream = null;
        this.Stream = null;
        
        this.InternInfra.StringDelete(this.InternHostName);
        return true;
    }

    public virtual bool Abort()
    {
        Extern.Network_Abort(this.Intern);
        return true;
    }

    private StreamStream StreamCreateIntern(ulong u)
    {
        Stream a;
        a = new Stream();
        a.SetIntern = u;
        a.Init();
        StreamStream o;
        o = a;
        return o;
    }

    protected virtual StreamStream StreamCreate()
    {
        Stream a;
        a = new Stream();
        a.Init();
        StreamStream o;
        o = a;
        return o;
    }

    protected virtual bool ExecuteStatusChangeState()
    {
        return true;
    }

    protected virtual bool CaseChange()
    {
        CaseList caseList;
        caseList = this.NetworkCaseList;

        Case k;
        k = this.Case;
        
        if (k == caseList.Connected)
        {
            this.Stream = this.DataStream;
            this.LoadingOpen = false;
        }

        this.ExecuteCaseChangeState();
        return true;
    }

    protected virtual bool ExecuteCaseChangeState()
    {
        return true;
    }

    protected virtual bool ExecuteReadyRead()
    {
        return true;
    }

    internal static ulong InternStatusChange(ulong network, ulong arg)
    {
        InternIntern internIntern;
        internIntern = InternIntern.This;

        object ao;
        ao = internIntern.HandleTarget(arg);

        Network a;
        a = (Network)ao;
        a.ExecuteStatusChangeState();

        return 1;
    }

    internal static ulong InternCaseChange(ulong network, ulong arg)
    {
        InternIntern internIntern;
        internIntern = InternIntern.This;

        object ao;
        ao = internIntern.HandleTarget(arg);

        Network a;
        a = (Network)ao;
        a.CaseChange();

        return 1;
    }

    internal static ulong InternReadyRead(ulong network, ulong arg)
    {
        InternIntern internIntern;
        internIntern = InternIntern.This;

        object ao;
        ao = internIntern.HandleTarget(arg);

        Network a;
        a = (Network)ao;
        a.ExecuteReadyRead();

        return 1;
    }
}