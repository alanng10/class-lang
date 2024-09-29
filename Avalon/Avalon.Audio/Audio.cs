namespace Avalon.Audio;

public class Audio : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternData = Extern.Data_New();
        Extern.Data_Init(this.InternData);

        this.Intern = Extern.Audio_New();
        Extern.Audio_DataSet(this.Intern, this.InternData);
        Extern.Audio_Init(this.Intern);
        this.Ident = this.Intern;
        return true;
    }

    public virtual bool Final()
    {
        Extern.Image_Final(this.Intern);
        Extern.Image_Delete(this.Intern);

        Extern.Data_Final(this.InternData);
        Extern.Data_Delete(this.InternData);
        return true;
    }

    public virtual long Count { get; set; }
    public virtual long Time { get; set; }
    private ulong Intern { get; set; }
    private ulong InternData { get; set; }

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