namespace Avalon.Network;

public class Network : Any
{
    private bool PrivateStatusEvent()
    {
        this.StatusEvent();
        return true;
    }

    private bool PrivateCaseEvent()
    {
        if (this.Case == this.NetworkCaseList.Connected)
        {
            this.Stream = this.DataStream;
            this.LoadingOpen = false;
        }

        this.CaseEvent();
        return true;
    }

    private bool PrivateDataEvent()
    {
        this.DataEvent();
        return true;
    }

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
        oa = this.NetworkInfra.NetworkStatusEventMaideAddress;
        MaideAddress ob;
        ob = this.NetworkInfra.NetworkCaseEventMaideAddress;
        MaideAddress oc;
        oc = this.NetworkInfra.NetworkDataEventMaideAddress;
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

            long ident;
            ident = (long)streamU;
            this.DataStream = this.StreamCreateSet(ident);
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
            return false;
        }
        if (this.LoadingOpen)
        {
            return false;
        }

        this.LoadingOpen = true;

        this.InternHostName = this.InternInfra.StringCreate(this.HostName);
        ulong hostPortU;
        hostPortU = (ulong)this.HostPort;
        this.DataStream = this.StreamCreate();

        ulong k;
        k = (ulong)this.DataStream.Ident;

        Extern.Network_HostNameSet(this.Intern, this.InternHostName);
        Extern.Network_HostPortSet(this.Intern, hostPortU);
        Extern.Network_StreamSet(this.Intern, k);
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

    protected virtual StreamStream StreamCreateSet(long ident)
    {
        Stream k;
        k = new Stream();
        k.InitIdent = ident;
        k.Init();
        StreamStream a;
        a = k;
        return a;
    }

    protected virtual StreamStream StreamCreate()
    {
        Stream k;
        k = new Stream();
        k.Init();
        StreamStream a;
        a = k;
        return a;
    }

    public virtual bool StatusEvent()
    {
        return false;
    }

    public virtual bool CaseEvent()
    {
        return false;
    }

    public virtual bool DataEvent()
    {
        return false;
    }

    internal static ulong InternStatusEvent(ulong network, ulong arg)
    {
        InternIntern internIntern;
        internIntern = InternIntern.This;

        object ao;
        ao = internIntern.HandleTarget(arg);

        Network a;
        a = (Network)ao;
        a.PrivateStatusEvent();

        return 1;
    }

    internal static ulong InternCaseEvent(ulong network, ulong arg)
    {
        InternIntern internIntern;
        internIntern = InternIntern.This;

        object ao;
        ao = internIntern.HandleTarget(arg);

        Network a;
        a = (Network)ao;
        a.PrivateCaseEvent();

        return 1;
    }

    internal static ulong InternDataEvent(ulong network, ulong arg)
    {
        InternIntern internIntern;
        internIntern = InternIntern.This;

        object ao;
        ao = internIntern.HandleTarget(arg);

        Network a;
        a = (Network)ao;
        a.PrivateDataEvent();

        return 1;
    }
}