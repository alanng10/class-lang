namespace Avalon.Media;

public class AudioOut : Any
{
    public override bool Init()
    {
        base.Init();
        this.Intern = Extern.AudioOut_New();
        Extern.AudioOut_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.AudioOut_Final(this.Intern);
        Extern.AudioOut_Delete(this.Intern);
        return true;
    }

    internal virtual ulong Intern { get; set; }

    public virtual bool Muted
    {
        get
        {
            ulong u;
            u = Extern.AudioOut_MutedGet(this.Intern);
            bool a;
            a = !(u == 0);
            return a;
        }
        set
        {
            ulong u;
            u = (ulong)(value ? 1 : 0);
            Extern.AudioOut_MutedSet(this.Intern, u);
        }
    }

    public virtual long Volume
    {
        get
        {
            ulong u;
            u = Extern.AudioOut_VolumeGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
            ulong u;
            u = (ulong)value;
            Extern.AudioOut_VolumeSet(this.Intern, u);
        }
    }
}