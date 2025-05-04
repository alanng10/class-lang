namespace Avalon.Network;

public class Network : Any
{
    public override bool Init()
    {
        base.Init();

        bool b;
        b = (this.HostPeer == null);
        if (b)
        {
            this.Intern = Extern.Network_New();
            Extern.Network_Init(this.Intern);
        }
        if (!b)
        {
            this.Intern = this.HostPeer as SystemNetwork;

            long ident;
            ident = (long)streamU;
            this.DataStream = this.StreamCreateSet(ident);
            this.Stream = this.DataStream;
        }
        return true;
    }

    public virtual bool Final()
    {
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
        return true;
    }

    public virtual object HostPeer { get; set; }
    public virtual String HostName { get; set; }
    public virtual long HostPort { get; set; }
    public virtual StreamStream Stream { get; set; }
    protected virtual StringValue StringValue { get; set; }
    protected virtual StreamStream DataStream { get; set; }
    protected virtual object StreamIdent { get; set; }
    private SystemNetwork Intern { get; set; }

    public virtual bool Open()
    {
        if (!(this.Stream == null))
        {
            return false;
        }

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
        this.LoadOpen = false;

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

    protected virtual StreamStream CreateStream()
    {
        object kk;
        kk = this.StreamIdent;

        if (kk == null)
        {
            return null;
        }

        Stream k;
        k = new Stream();
        k.SetIdent = kk;
        k.Init();
        StreamStream a;
        a = k;
        return a;
    }
}