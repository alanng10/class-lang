namespace Avalon.Storage;

public class Storage : Any
{
    public override bool Init()
    {
        base.Init();
        this.StorageInfra = Infra.This;
        this.StringValue = StringValue.This;
        return true;
    }

    public virtual bool Final()
    {
        return true;
    }

    public virtual String Path { get; set; }
    public virtual Mode Mode { get; set; }
    public virtual StreamStream Stream { get; set; }
    protected virtual Infra StorageInfra { get; set; }
    protected virtual StringValue StringValue { get; set; }

    public virtual bool Open()
    {
        if (!(this.Stream == null))
        {
            return false;
        }
        if (!this.StorageInfra.ValidMode(this.Mode))
        {
            return false;
        }

        StreamStream stream;
        stream = this.CreateStream();

        if (stream == null)
        {
            return false;
        }

        this.Stream = stream;
        return true;
    }

    public virtual bool Close()
    {
        if (!(this.Stream == null))
        {
            this.Stream.Final();
        }
        this.Stream = null;
        return true;
    }

    public virtual bool CountSet(long value)
    {
        if (this.Stream == null)
        {
            return false;
        }

        SystemStorageStream k;
        k = this.Stream.Ident as SystemStorageStream;

        try
        {
            k.SetLength(value);
        }
        catch
        {
            return false;
        }
        return true;
    }

    protected virtual object CreateStreamIdent()
    {
        string path;
        path = this.StringValue.ExecuteIntern(this.Path);

        SystemStorageMode mode;
        mode = this.InternMode(this.Mode);

        SystemStorageAccess access;
        access = this.InternAccess(this.Mode);

        SystemStorageStream k;
        try
        {
            k = new SystemStorageStream(path, mode, access);
        }
        catch
        {
            return null;
        }
        return k;
    }

    protected virtual StreamStream CreateStream()
    {
        object kk;
        kk = this.CreateStreamIdent();

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

    private SystemStorageMode InternMode(Mode mode)
    {
        if (mode.Read & mode.Write)
        {
            if (mode.New)
            {
                return SystemStorageMode.CreateNew;
            }
            if (mode.Exist)
            {
                return SystemStorageMode.Open;
            }
        }

        if (mode.Write)
        {
            if (mode.New)
            {
                return SystemStorageMode.CreateNew;
            }

            if (mode.Exist)
            {
                return SystemStorageMode.Truncate;
            }

            return SystemStorageMode.Create;
        }
        
        return SystemStorageMode.Open;
    }

    private SystemStorageAccess InternAccess(Mode mode)
    {
        if (mode.Read & mode.Write)
        {
            return SystemStorageAccess.ReadWrite;
        }

        if (mode.Read)
        {
            return SystemStorageAccess.Read;
        }

        if (mode.Write)
        {
            return SystemStorageAccess.Write;
        }
        return 0;
    }
}