namespace Avalon.Audio;

public class Audio : Any
{
    public virtual long Count { get; set; }
    public virtual long Time { get; set; }
    private ulong Intern { get; set; }

    public virtual bool DataCreate()
    {
        long count;
        count = this.Count;
        long time;
        time = this.Time;

        ulong countU;
        countU = (ulong)count;
        ulong timeU;
        timeU = (ulong)time;
        Extern.Audio_CountSet(this.Intern, countU);
        Extern.Audio_TimeSet(this.Intern, timeU);

        Extern.Audio_DataCreate(this.Intern);
        return true;
    }
}