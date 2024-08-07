namespace Avalon.Intern;

public class Infra : object
{
    public static Infra This { get; } = ShareCreate();

    private static Infra ShareCreate()
    {
        Infra share;
        share = new Infra();
        share.Init();
        return share;
    }

    public virtual bool Init()
    {
        this.InternIntern = Intern.This;


        this.SystemTickMin = DateTime.MinValue.Ticks;
        this.SystemTickMax = DateTime.MaxValue.Ticks;

        double k;
        k = TimeSpan.TicksPerDay;

        long ka;
        ka = 1;
        ka = ka << 30;

        k = k / ka;

        this.SystemTickPerTick = k;
        return true;
    }

    protected virtual Intern InternIntern { get; set; }

    public virtual long SystemTickMin { get; set; }

    public virtual long SystemTickMax { get; set; }

    public virtual double SystemTickPerTick { get; set; }

    public virtual ulong StringCreate(string a)
    {
        int k;
        k = a.Length;

        ulong count;
        count = (ulong)k;

        ulong byteCount;
        byteCount = count * 2;

        ulong data;
        data = Extern.New(byteCount);

        this.InternIntern.CopyString(data, a, 0, count);
 
        ulong o;
        o = Extern.String_New();
        Extern.String_Init(o);
        Extern.String_CountSet(o, count);
        Extern.String_DataSet(o, data);
        return o;
    }

    public virtual bool StringDelete(ulong o)
    {
        ulong data;
        data = Extern.String_DataGet(o);

        Extern.String_Final(o);
        Extern.String_Delete(o);

        Extern.Delete(data);
        return true;
    }
    
    public virtual ulong StateCreate(MaideAddress maideAddress, ulong arg)
    {
        ulong a;
        a = Extern.State_New();
        Extern.State_Init(a);
        Extern.State_MaideSet(a, maideAddress.Value);
        Extern.State_ArgSet(a, arg);
        return a;
    }

    public virtual bool StateDelete(ulong o)
    {
        Extern.State_Final(o);
        Extern.State_Delete(o);
        return true;
    }

    public virtual ulong RangeCreate()
    {
        ulong o;
        o = Extern.Range_New();
        Extern.Range_Init(o);
        return o;
    }

    public virtual bool RangeDelete(ulong o)
    {
        Extern.Range_Final(o);
        Extern.Range_Delete(o);
        return true;
    }

    public virtual ulong PosCreate()
    {
        ulong o;
        o = Extern.Pos_New();
        Extern.Pos_Init(o);
        return o;
    }

    public virtual bool PosDelete(ulong o)
    {
        Extern.Pos_Final(o);
        Extern.Pos_Delete(o);
        return true;
    }

    public virtual ulong RectCreate()
    {
        ulong pos;
        pos = Extern.Pos_New();
        Extern.Pos_Init(pos);

        ulong size;
        size = Extern.Size_New();
        Extern.Size_Init(size);

        ulong rect;
        rect = Extern.Rect_New();
        Extern.Rect_Init(rect);
        Extern.Rect_PosSet(rect, pos);
        Extern.Rect_SizeSet(rect, size);
        return rect;
    }

    public virtual bool RectDelete(ulong rect)
    {
        ulong pos;
        ulong size;
        
        pos = Extern.Rect_PosGet(rect);

        size = Extern.Rect_SizeGet(rect);

        Extern.Rect_Final(rect);
        Extern.Rect_Delete(rect);

        Extern.Size_Final(size);
        Extern.Size_Delete(size);

        Extern.Pos_Final(pos);
        Extern.Pos_Delete(pos);
        return true;
    }

    public virtual bool RectSet(ulong rect, long left, long up, long width, long height)
    {
        ulong pos;
        pos = Extern.Rect_PosGet(rect);

        this.PosSet(pos, left, up);

        ulong size;
        size = Extern.Rect_SizeGet(rect);

        this.SizeSet(size, width, height);
        return true;
    }

    public virtual bool RangeSet(ulong range, long index, long count)
    {
        ulong indexU;
        ulong countU;
        indexU = (ulong)index;
        countU = (ulong)count;

        Extern.Range_IndexSet(range, indexU);
        Extern.Range_CountSet(range, countU);
        return true;
    }

    public virtual bool PosSet(ulong pos, long left, long up)
    {
        ulong l;
        ulong u;
        l = (ulong)left;
        u = (ulong)up;

        Extern.Pos_LeftSet(pos, l);
        Extern.Pos_UpSet(pos, u);
        return true;
    }

    public virtual bool SizeSet(ulong size, long width, long height)
    {
        ulong w;
        ulong h;
        w = (ulong)width;
        h = (ulong)height;

        Extern.Size_WidthSet(size, w);
        Extern.Size_HeightSet(size, h);
        return true;
    }

    public virtual long SystemTickToTick(long value)
    {
        double k;
        k = value;
        k = k / this.SystemTickPerTick;

        long a;
        a = (long)k;
        return a;
    }

    public virtual long TickToSystemTick(long value)
    {
        double k;
        k = value;
        k = k * this.SystemTickPerTick;

        long a;
        a = (long)k;
        return a;
    }
}