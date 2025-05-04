namespace Avalon.Network;

public class Host : Any
{
    public virtual Port Port { get; set; }
    private SystemNetworkHost Intern { get; set; }

    public virtual bool Open()
    {
        SystemNetworkPort internPort;
        internPort = this.InternPort();

        if (internPort == null)
        {
            return false;
        }

        try
        {
            this.Intern = new SystemNetworkHost(internPort);
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

    private SystemNetworkPort InternPort()
    {
        int host;
        host = (int)this.Port.Host;

        SystemNetworkPort k;
        k = null;

        try
        {
            SystemNetworkAddress kc;
            kc = null;

            bool b;
            b = (this.Port.ValueB == null);

            if (b)
            {
                kc = new SystemNetworkAddress(this.Port.ValueA);
            }

            if (!b)
            {
                byte[] kaa;
                kaa = this.Port.ValueB.Value as byte[];

                kc = new SystemNetworkAddress(kaa);
            }


            k = new SystemNetworkPort(kc, host);
        }
        catch
        {
            return null;
        }

        return k;
    }
}