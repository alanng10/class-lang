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
        oa = this.NetworkInfra.NetworkCaseChangedMaideAddress;
        MaideAddress ob;
        ob = this.NetworkInfra.NetworkReadyReadMaideAddress;
        ulong arg;
        arg = this.InternHandle.ULong();
        this.InternCaseChangedState = this.InternInfra.StateCreate(oa, arg);
        this.InternReadyReadState = this.InternInfra.StateCreate(ob, arg);

        bool b;
        b = (this.SetIntern == 0);
        if (b)
        {
            this.Intern = Extern.Network_New();
            Extern.Network_Init(this.Intern);
        }
        if (!b)
        {
            this.Intern = this.SetIntern;

            ulong streamU;
            streamU = Extern.Network_GetStream(this.Intern);
            this.DataStream = this.StreamCreateIntern(streamU);
            this.Stream = this.DataStream;
        }

        Extern.Network_SetCaseChangedState(this.Intern, this.InternCaseChangedState);
        Extern.Network_SetReadyReadState(this.Intern, this.InternReadyReadState);
        return true;
    }

    public virtual bool Final()
    {
        bool b;
        b = (this.SetIntern == 0);
        
        if (b)
        {
            Extern.Network_Final(this.Intern);
            Extern.Network_Delete(this.Intern);
        }
        if (!b)
        {
            this.DataStream.Final();
        }

        this.InternInfra.StateDelete(this.InternReadyReadState);
        this.InternInfra.StateDelete(this.InternCaseChangedState);

        this.InternHandle.Final();
        return true;
    }

    internal virtual ulong SetIntern { get; set; }
    public virtual string HostName { get; set; }
    public virtual int Port { get; set; }
    public virtual State CaseChangedState { get; set; }
    public virtual State ReadyReadState { get; set; }
    public virtual StreamStream Stream { get; set; }
    protected virtual StreamStream DataStream { get; set; }
    public virtual bool LoadingOpen { get; set; }

    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    private Infra NetworkInfra { get; set; }
    protected virtual CaseList NetworkCaseList { get; set; }
    protected virtual StatusList NetworkStatusList { get; set; }

    internal virtual ulong Intern { get; set; }
    private ulong InternReadyReadState { get; set; }
    private ulong InternCaseChangedState { get; set; }
    private Handle InternHandle { get; set; }
    private ulong InternHostName { get; set; }

    public virtual Status Status
    {
        get
        {
            ulong u;
            u = Extern.Network_GetStatus(this.Intern);
            int o;
            o = (int)u;
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
            u = Extern.Network_GetCase(this.Intern);
            if (u == 0)
            {
                return null;
            }
            u = u - 1;
            int o;
            o = (int)u;
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
            u = Extern.Network_GetReadyCount(this.Intern);
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

        this.InternHostName = this.InternInfra.StringCreate(this.HostName);
        ulong portU;
        portU = (ulong)this.Port;
        this.DataStream = this.StreamCreate();

        Extern.Network_SetHostName(this.Intern, this.InternHostName);
        Extern.Network_SetPort(this.Intern, portU);
        Extern.Network_SetStream(this.Intern, this.DataStream.Ident);
        Extern.Network_Open(this.Intern);
        return true;
    }

    public virtual bool Close()
    {   
        Extern.Network_Close(this.Intern);
        Extern.Network_SetStream(this.Intern, 0);
        Extern.Network_SetPort(this.Intern, 0);
        Extern.Network_SetHostName(this.Intern, 0);

        this.DataStream.Final();
        this.DataStream = null;
        this.Stream = null;

        this.InternInfra.StringDelete(this.InternHostName);

        this.LoadingOpen = false;
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

    private bool CaseChanged()
    {
        if (this.Case == this.NetworkCaseList.Connected)
        {
            this.Stream = this.DataStream;
            this.LoadingOpen = false;
        }

        this.ExecuteCaseChangedState();
        return true;
    }

    private bool ExecuteCaseChangedState()
    {
        if (!(this.CaseChangedState == null))
        {
            this.CaseChangedState.Execute();
        }
        return true;
    }

    private bool ExecuteReadyReadState()
    {
        if (!(this.ReadyReadState == null))
        {
            this.ReadyReadState.Execute();
        }
        return true;
    }

    internal static ulong InternCaseChanged(ulong network, ulong arg)
    {
        InternIntern internIntern;
        internIntern = InternIntern.This;

        object ao;
        ao = internIntern.HandleTarget(arg);

        Network a;
        a = (Network)ao;
        a.CaseChanged();

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
        a.ExecuteReadyReadState();

        return 1;
    }
}