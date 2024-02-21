namespace Avalon.Video;

public class Video : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.VideoInfra = Infra.This;

        this.Size = new Size();
        this.Size.Init();

        this.InternSize = Extern.Size_New();
        Extern.Size_Init(this.InternSize);
        this.InternData = Extern.Data_New();
        Extern.Data_Init(this.InternData);
        this.Intern = Extern.Image_New();
        Extern.Image_SetSize(this.Intern, this.InternSize);
        Extern.Image_SetData(this.Intern, this.InternData);
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

        if (!(this.InternDataValue == 0))
        {
            Extern.Delete(this.InternDataValue);
        }
        return true;
    }

    public virtual bool CreateData()
    {
        if (!(this.InternDataValue == 0))
        {
            Extern.Delete(this.InternDataValue);
        }

        int width;
        int height;
        width = this.Size.Width;
        height = this.Size.Height;
        ulong w;
        ulong h;
        w = (ulong)width;
        h = (ulong)height;
        Extern.Size_SetWidth(this.InternSize, w);
        Extern.Size_SetHeight(this.InternSize, h);

        int aa;
        aa = this.VideoInfra.PixelByteCount;
        ulong uaa;
        uaa = (ulong)aa;
        ulong dataCount;
        dataCount = w * h * uaa;

        this.InternDataValue = Extern.New(dataCount);
        Extern.Data_SetCount(this.InternData, dataCount);
        Extern.Data_SetValue(this.InternData, this.InternDataValue);
        Extern.Image_CreateData(this.Intern);
        return true;
    }

    public virtual Size Size { get; set; }

    public virtual ulong Data
    {
        get
        {
            return Extern.Data_GetValue(this.InternData);
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
            u = Extern.Image_GetRowByteCount(this.Intern);
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
            return Extern.Image_GetVideoOut(this.Intern);
        }
        set
        {
        }
    }

    public virtual ulong Ident { get; set; }

    private InternIntern InternIntern { get; set; }
    protected virtual Infra VideoInfra { get; set; }

    internal virtual ulong Intern { get; set; }
    private ulong InternData { get; set; }
    private ulong InternSize { get; set; }
    private ulong InternDataValue { get; set; }
}