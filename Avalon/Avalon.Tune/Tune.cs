namespace Avalon.Tune;

public class Tune : Any
{
    public override bool Init()
    {
        base.Init();
        // this.Intern = Extern.Tune_New();
        // Extern.Tune_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        // Extern.Tune_Final(this.Intern);
        // Extern.Tune_Delete(this.Intern);
        return true;
    }

    public virtual ulong Out { get; set; }
    private ulong Intern { get; set; }

    public virtual bool ExecuteAudio(AudioAudio audio, Range destRange, Range sourceRange)
    {
        return true;
    }
}