namespace Avalon.Infra;

public class InternInfra : Any
{
    public static InternInfra This { get; } = ShareCreate();

    private static InternInfra ShareCreate()
    {
        InternInfra share;
        share = new InternInfra();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.InternIntern = Intern.This;

        long o;
        o = 1;
        o = o << 60;
        this.IntCapValue = o;
        return true;
    }

    public virtual String ModuleFoldPath { get; set; }
    protected virtual long IntCapValue { get; set; }
    protected virtual Intern InternIntern { get; set; }

    public virtual ulong StringCreate(String k)
    {
        object value;
        value = this.InternIntern.StringValueGet(k);

        long count;
        count = this.InternIntern.StringCountGet(k);

        ulong countA;
        countA = (ulong)count;

        ulong ka;
        ka = countA * sizeof(uint);

        ulong kk;
        kk = Extern.Environ_New(ka);

        this.InternIntern.CopyFromByteArray(kk, value, 0, ka);

        ulong a;
        a = Extern.String_New();
        Extern.String_Init(a);
        Extern.String_ValueSet(a, kk);
        Extern.String_CountSet(a, countA);
        return a;
    }

    public virtual bool StringDelete(ulong k)
    {
        ulong value;
        value = Extern.String_ValueGet(k);

        Extern.String_Final(k);
        Extern.String_Delete(k);

        Extern.Environ_Delete(value);
        return true;
    }

    public virtual String StringCreateIntern(ulong k)
    {
        object value;
        value = this.ByteArrayCreateString(k);

        ulong count;
        count = Extern.String_CountGet(k);

        long countA;
        countA = (long)count;

        String a;
        a = this.InternIntern.StringNew();
        this.InternIntern.StringValueSet(a, value);
        this.InternIntern.StringCountSet(a, countA);
        return a;
    }

    public virtual object ByteArrayCreateString(ulong k)
    {
        ulong value;
        ulong count;
        value = Extern.String_ValueGet(k);
        count = Extern.String_CountGet(k);

        ulong dataCount;
        dataCount = count * sizeof(uint);

        long ka;
        ka = (long)dataCount;

        object a;
        a = this.InternIntern.DataNew(ka);

        this.InternIntern.CopyToByteArray(value, a, 0, dataCount);
        return a;
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
        ulong a;
        a = Extern.Pos_New();
        Extern.Pos_Init(a);
        return a;
    }

    public virtual bool PosDelete(ulong a)
    {
        Extern.Pos_Final(a);
        Extern.Pos_Delete(a);
        return true;
    }

    public virtual ulong SizeCreate()
    {
        ulong a;
        a = Extern.Size_New();
        Extern.Size_Init(a);
        return a;
    }

    public virtual bool SizeDelete(ulong a)
    {
        Extern.Size_Final(a);
        Extern.Size_Delete(a);
        return true;
    }

    public virtual ulong RectCreate()
    {
        ulong pos;
        pos = this.PosCreate();

        ulong size;
        size = this.SizeCreate();

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

        this.SizeDelete(size);

        this.PosDelete(pos);
        return true;
    }

    public virtual bool RectSet(ulong rect, long col, long row, long wed, long het)
    {
        ulong pos;
        pos = Extern.Rect_PosGet(rect);

        this.PosSet(pos, col, row);

        ulong size;
        size = Extern.Rect_SizeGet(rect);

        this.SizeSet(size, wed, het);
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

    public virtual bool PosSet(ulong pos, long col, long row)
    {
        ulong c;
        ulong r;
        c = (ulong)col;
        r = (ulong)row;

        Extern.Pos_ColSet(pos, c);
        Extern.Pos_RowSet(pos, r);
        return true;
    }

    public virtual bool SizeSet(ulong size, long width, long hegth)
    {
        ulong w;
        ulong h;
        w = (ulong)width;
        h = (ulong)hegth;

        Extern.Size_WidthSet(size, w);
        Extern.Size_HegthSet(size, h);
        return true;
    }

    public virtual long DataByteListGet(object data, long index, long count)
    {
        Intern internIntern;
        internIntern = this.InternIntern;

        ulong oo;
        oo = 0;

        long i;
        i = 0;
        while (i < count)
        {
            long ob;
            ob = internIntern.DataGet(data, index + i);

            int shiftCount;
            shiftCount = (int)(i * 8);

            ulong o;
            o = (ulong)ob;
            o = o << shiftCount;

            oo = oo | o;

            i = i + 1;
        }
        long d;
        d = (this.IntCapValue - 1);
        ulong da;
        da = (ulong)d;
        ulong ka;
        ka = oo;
        ka = ka & da;

        long a;
        a = (long)ka;
        return a;
    }

    public virtual bool DataByteListSet(object data, long index, long count, long value)
    {
        Intern internIntern;
        internIntern = this.InternIntern;

        long d;
        d = this.IntCapValue - 1;
        ulong da;
        da = (ulong)d;
        ulong db;
        db = (ulong)value;
        ulong oo;
        oo = db;
        oo = oo & da;

        long i;
        i = 0;
        while (i < count)
        {
            int shiftCount;
            shiftCount = (int)(i * 8);

            ulong o;
            o = oo >> shiftCount;

            long oa;
            oa = (long)o;

            internIntern.DataSet(data, index + i, oa);

            i = i + 1;
        }
        return true;
    }

    public virtual long DataMidGet(object data, long index)
    {
        return this.DataByteListGet(data, index, sizeof(uint));
    }

    public virtual bool DataMidSet(object data, long index, long value)
    {
        return this.DataByteListSet(data, index, sizeof(uint), value);
    }

    public virtual long DataCharGet(object data, long index)
    {
        return this.DataMidGet(data, index);
    }

    public virtual bool DataCharSet(object data, long index, long value)
    {
        return this.DataMidSet(data, index, value);
    }

    public virtual long TypeIndexFromInternIndex(long n)
    {
        long k;
        k = n;

        long na;
        na = 0x01000000;

        long nb;
        nb = 0x80;

        if (!(k < na))
        {
            k = k - na;
            k = k + nb;
        }
        return k;
    }
}