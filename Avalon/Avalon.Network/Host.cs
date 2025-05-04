namespace Avalon.Network;

public class Host : Any
{
    public override bool Init()
    {
        base.Init();
        return true;
    }

    public virtual bool Final()
    {
        return true;
    }

    public virtual Port Port { get; set; }
    private SystemNetworkHost Intern { get; set; }
    private SystemNetworkPort InternPort { get; set; }

    public virtual bool Open()
    {
        this.InternPortSet();

        try
        {
            this.Intern = new SystemNetworkHost(this.InternPort);
        }
        catch
        {
            return false;
        }

        try
        {
            this.Intern.Start();
        }
        catch
        {
            try
            {
                this.Intern.Dispose();
            }
            catch
            {
            }

            this.Intern = null;

            return false;
        }

        return true;
    }

    public virtual bool Close()
    {
        try
        {
            this.Intern.Stop();
        }
        catch
        {
        }

        try
        {
            this.Intern.Dispose();
        }
        catch
        {
        }

        this.Intern = null;

        return true;
    }

    public virtual bool Reque()
    {
        return this.Intern.Pending();
    }

    public virtual Network OpenPeer()
    {
        ulong k;
        k = Extern.NetworkHost_OpenPeer(this.Intern);

        Network a;
        a = this.CreatePeer(k);
        return a;
    }

    public virtual bool ClosePeer(Network a)
    {
        ulong k;
        k = a.HostPeer;

        this.FinalPeer(a);

        Extern.NetworkHost_ClosePeer(this.Intern, k);
        return true;
    }

    protected virtual Network CreatePeer(ulong peer)
    {
        Network a;
        a = new Network();
        a.HostPeer = peer;
        a.Init();
        return a;
    }

    protected virtual bool FinalPeer(Network a)
    {
        a.Final();
        return true;
    }

    private bool InternPortSet()
    {
        ulong kindU;
        kindU = this.Port.Kind.Intern;
        ulong valueAU;
        ulong valueBU;
        ulong valueCU;
        ulong hostU;
        valueAU = (ulong)this.Port.ValueA;
        valueBU = (ulong)this.Port.ValueB;
        valueCU = (ulong)this.Port.ValueC;
        hostU = (ulong)this.Port.Host;

        Extern.NetworkPort_KindSet(this.InternPort, kindU);
        Extern.NetworkPort_ValueASet(this.InternPort, valueAU);
        Extern.NetworkPort_ValueBSet(this.InternPort, valueBU);
        Extern.NetworkPort_ValueCSet(this.InternPort, valueCU);
        Extern.NetworkPort_HostSet(this.InternPort, hostU);
        Extern.NetworkPort_Set(this.InternPort);
        return true;
    }

    public virtual bool NewPeer()
    {
        return false;
    }
}