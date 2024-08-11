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
        return true;
    }

    protected virtual Intern InternIntern { get; set; }

    public virtual ulong StringCreate(string o)
    {
        int countA;
        countA = o.Length;

        ulong kk;
        kk = (ulong)countA;

        ulong dataCount;
        dataCount = kk * sizeof(char);

        ulong varShare;
        varShare = Extern.Infra_Share();
        ulong stat;
        stat = Extern.Share_Stat(varShare);

        ulong innKind;
        ulong outKind;
        innKind = Extern.Stat_TextEncodeKindUtf16(stat);
        outKind = Extern.Stat_TextEncodeKindUtf32(stat);

        ulong resultCount;
        resultCount = this.InternIntern.TextEncodeCountString(innKind, outKind, o, 0, dataCount);

        ulong result;
        result = Extern.New(resultCount);

        this.InternIntern.TextEncodeResultString(result, innKind, outKind, o, 0, dataCount);
 
        ulong count;
        count = resultCount / 4;

        ulong a;
        a = Extern.String_New();
        Extern.String_Init(a);
        Extern.String_DataSet(a, result);
        Extern.String_CountSet(a, count);
        return a;
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
}