namespace Avalon.Video;

public class Video : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InfraInfra = InfraInfra.This;
        this.VideoInfra = Infra.This;

        this.Size = new Size();
        this.Size.Init();

        this.InternSize = Extern.Size_New();
        Extern.Size_Init(this.InternSize);
        this.InternData = Extern.Data_New();
        Extern.Data_Init(this.InternData);
        this.Intern = Extern.Image_New();
        Extern.Image_SizeSet(this.Intern, this.InternSize);
        Extern.Image_DataSet(this.Intern, this.InternData);
        Extern.Image_Init(this.Intern);
        this.Ident = this.Intern;
        return true;
    }

    public virtual bool Final()
    {
        Extern.Image_Final(this.Intern);
        Extern.Image_Delete(this.Intern);

        Extern.Data_Final(this.InternData);
        Extern.Data_Delete(this.InternData);

        Extern.Size_Final(this.InternSize);
        Extern.Size_Delete(this.InternSize);
        return true;
    }

    public virtual ulong Ident { get; set; }

    private InternIntern InternIntern { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual Infra VideoInfra { get; set; }
    internal virtual ulong Intern { get; set; }
    private ulong InternData { get; set; }
    private ulong InternSize { get; set; }

    public virtual bool DataCreate()
    {
        int width;
        int height;
        width = this.Size.Width;
        height = this.Size.Height;
        ulong w;
        ulong h;
        w = (ulong)width;
        h = (ulong)height;
        Extern.Size_WidthSet(this.InternSize, w);
        Extern.Size_HeightSet(this.InternSize, h);

        Extern.Image_DataCreate(this.Intern);
        return true;
    }

    public virtual bool DataGet(Data data, long index)
    {
        int w;
        int h;
        w = this.Size.Width;
        h = this.Size.Height;
        int k;
        k = this.VideoInfra.PixelByteCount;

        long ka;
        ka = w;
        ka = ka * h;
        ka = ka * k;

        long count;
        count = ka;

        if (!this.InfraInfra.CheckLongRange(data.Count, index, count))
        {
            return false;
        }

        ulong a;
        a = Extern.Data_ValueGet(this.InternData);
        
        this.InternIntern.VideoDataGet(a, data.Value, index, k, w, h);
        return true;
    }

    public virtual Size Size { get; set; }

    public virtual ulong Data
    {
        get
        {
            return Extern.Data_ValueGet(this.InternData);
        }
        set
        {
        }
    }

    public virtual int RowByteCount
    {
        get
        {
            ulong u;
            u = Extern.Image_RowByteCountGet(this.Intern);
            int a;
            a = (int)u;
            return a;
        }
        set
        {
        }
    }

    public virtual ulong Out
    {
        get
        {
            return Extern.Image_VideoOut(this.Intern);
        }
        set
        {
        }
    }
}