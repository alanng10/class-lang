namespace Avalon.Audio;

public class Effect : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
        
        this.InternSource = this.InternInfra.StringCreate(this.Source);

        this.Intern = Extern.AudioEffect_New();
        Extern.AudioEffect_Init(this.Intern);
        Extern.AudioEffect_SourceSet(this.Intern, this.InternSource);
        Extern.AudioEffect_SetAudioSource(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.AudioEffect_Final(this.Intern);
        Extern.AudioEffect_Delete(this.Intern);

        this.InternInfra.StringDelete(this.InternSource);
        return true;
    }

    public virtual string Source { get; set; }

    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    private ulong Intern { get; set; }
    private ulong InternSource { get; set; }

    public virtual long Volume
    {
        get
        {
            ulong u;
            u = Extern.AudioEffect_VolumeGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
            ulong u;
            u = (ulong)value;
            Extern.AudioEffect_VolumeSet(this.Intern, u);
        }
    }

    public virtual bool Play()
    {
        Extern.AudioEffect_Play(this.Intern);
        return true;
    }

    public virtual bool Stop()
    {
        Extern.AudioEffect_Stop(this.Intern);
        return true;
    }
}