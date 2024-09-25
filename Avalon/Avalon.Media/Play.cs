namespace Avalon.Media;

public class Play : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
        this.Intern = Extern.Play_New();
        Extern.Play_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.Play_Final(this.Intern);
        Extern.Play_Delete(this.Intern);
        return true;
    }

    public virtual StreamStream Stream { get; set; }

    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    private ulong Intern { get; set; }

    public virtual bool StreamSet()
    {
        ulong u;
        u = 0;
        if (!(this.Stream == null))
        {
            u = this.Stream.Ident;
        }
        // Extern.Play_StreamSet(this.Intern, u);
        // Extern.Play_StreamThisSet(this.Intern);
        return true;
    }

    public virtual bool Execute()
    {
        Extern.Play_Execute(this.Intern);
        return true;
    }

    public virtual bool Pause()
    {
        Extern.Play_Pause(this.Intern);
        return true;
    }

    public virtual bool Stop()
    {
        Extern.Play_Stop(this.Intern);
        return true;
    }

    public virtual AudioOut AudioOut { get; set; }

    public virtual bool AudioOutSet()
    {
        ulong u;
        u = 0;
        if (!(this.AudioOut == null))
        {
            u = this.AudioOut.Intern;
        }
        Extern.Play_AudioOutSet(this.Intern, u);
        return true;
    }

    public virtual VideoOut VideoOut { get; set; }

    public virtual bool VideoOutSet()
    {
        ulong u;
        u = 0;
        if (!(this.VideoOut == null))
        {
            u = this.VideoOut.Intern;
        }
        Extern.Play_VideoOutSet(this.Intern, u);
        return true;
    }
}