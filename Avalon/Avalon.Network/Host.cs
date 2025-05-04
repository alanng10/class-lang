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
        object peer;
        
        try
        {
            peer = this.Intern.AcceptTcpClient();
        }
        catch
        {
            return null;
        }

        Network a;
        a = this.CreatePeer(peer);

        return a;
    }

    public virtual bool ClosePeer(Network a)
    {
        object k;
        k = a.HostPeer;

        this.FinalPeer(a);

        SystemNetwork ka;
        ka = k as SystemNetwork;

        try
        {
            ka.Close();
        }
        catch
        {
        }
        return true;
    }

    protected virtual Network CreatePeer(object peer)
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
        return true;
    }

    public virtual bool NewPeer()
    {
        return false;
    }
}