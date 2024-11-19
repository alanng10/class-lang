namespace Avalon.Stream;

public class Memory : Any
{
    public override bool Init()
    {
        base.Init();
        this.Intern = Extern.Memory_New();
        Extern.Memory_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.Memory_Final(this.Intern);
        Extern.Memory_Delete(this.Intern);
        return true;
    }

    public virtual Stream Stream { get; set; }
    private ulong Intern { get; set; }

    public virtual bool Open()
    {
        if (!(this.Stream == null))
        {
            return false;
        }

        Stream stream;
        stream = this.CreateStream();

        ulong k;
        k = (ulong)stream.Ident;

        Extern.Memory_StreamSet(this.Intern, k);
        Extern.Memory_Open(this.Intern);

        this.Stream = stream;
        return true;
    }

    public virtual bool Close()
    {
        Extern.Memory_Close(this.Intern);
        Extern.Memory_StreamSet(this.Intern, 0);

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