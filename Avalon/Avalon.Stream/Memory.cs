namespace Avalon.Stream;

public class Memory : Any
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

    public virtual Stream Stream { get; set; }

    public virtual bool Open()
    {
        if (!(this.Stream == null))
        {
            return false;
        }

        Stream stream;
        stream = this.CreateStream();

        this.Stream = stream;
        return true;
    }

    public virtual bool Close()
    {
        this.Stream.Final();
        this.Stream = null;
        return true;
    }

    protected virtual Stream CreateStream()
    {
        MemoryStream k;
        k = new MemoryStream();
        k.Init();
        Stream a;
        a = k;
        return a;
    }
}