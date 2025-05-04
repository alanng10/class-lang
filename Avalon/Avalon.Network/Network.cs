namespace Avalon.Network;

public class Network : Any
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

    public virtual object HostPeer { get; set; }
    public virtual String HostName { get; set; }
    public virtual long HostPort { get; set; }
    public virtual StreamStream Stream { get; set; }
    protected virtual StringValue StringValue { get; set; }
    private SystemNetwork Intern { get; set; }

    public virtual bool Open()
    {
        if (!(this.Stream == null))
        {
            return false;
        }

        string hostNameK;
        hostNameK = this.StringValue.ExecuteIntern(this.HostName);

        int hostPortK;
        hostPortK = (int)this.HostPort;

        try
        {
            this.Intern = new SystemNetwork(hostNameK, hostPortK);
        }
        catch
        {
            return false;
        }

        object streamIdent;
        try
        {
            streamIdent = this.Intern.GetStream();
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

        this.Stream = this.CreateStream(streamIdent);
        return true;
    }

    public virtual bool Close()
    {
        this.Intern.Dispose();
        this.Intern = null;

        this.Stream = null;
        return true;
    }

    protected virtual StreamStream CreateStream(object ident)
    {
        if (ident == null)
        {
            return null;
        }

        Stream k;
        k = new Stream();
        k.SetIdent = ident;
        k.Init();
        StreamStream a;
        a = k;
        return a;
    }
}