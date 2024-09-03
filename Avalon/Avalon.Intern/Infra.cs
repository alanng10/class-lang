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

        long o;
        o = 1;
        o = o << 60;
        this.IntCapValue = o;
        return true;
    }

    protected virtual long IntCapValue { get; set; }
    protected virtual Intern InternIntern { get; set; }

    public virtual ulong StringCreate(byte[] value)
    {
        long k;
        k = value.LongLength;
        ulong ka;
        ka = (ulong)k;

        ulong count;
        count = ka / sizeof(uint);

        ulong data;
        data = Extern.New(ka);

        this.InternIntern.CopyFromByteArray(data, value, 0, ka);

        ulong a;
        a = Extern.String_New();
        Extern.String_Init(a);
        Extern.String_DataSet(a, data);
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

    public virtual byte[] ByteArrayCreateReturnString(ulong u)
    {
        ulong data;
        ulong count;
        data = Extern.String_DataGet(u);
        count = Extern.String_CountGet(u);

        ulong dataCount;
        dataCount = count * sizeof(uint);

        long ka;
        ka = (long)dataCount;

        byte[] k;
        k = new byte[ka];

        this.InternIntern.CopyToByteArray(data, k, 0, dataCount);

        Extern.String_Final(u);
        Extern.String_Delete(u);

        Extern.Delete(data);
        return k;
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

    public virtual bool SizeSet(ulong size, long wed, long het)
    {
        ulong w;
        ulong h;
        w = (ulong)wed;
        h = (ulong)het;

        Extern.Size_WedSet(size, w);
        Extern.Size_HetSet(size, h);
        return true;
    }

    public virtual bool ValidIndex(long count, long index)
    {
        return this.ValidRange(count, index, 1);
    }

    public virtual bool ValidRange(long totalCount, long index, long count)
    {
        if (totalCount < 0)
        {
            return false;
        }
        if (index < 0)
        {
            return false;
        }
        if (count < 0)
        {
            return false;
        }
        if (totalCount < index + count)
        {
            return false;
        }
        return true;
    }

    public virtual ulong DataByteListGet(byte[] data, long index, long count)
    {
        ulong oo;
        oo = 0;

        long i;
        i = 0;
        while (i < count)
        {
            byte ob;
            ob = data[index + i];

            int shiftCount;
            shiftCount = (int)(i * 8);

            ulong o;
            o = ob;
            o = o << shiftCount;

            oo = oo | o;

            i = i + 1;
        }
        long d;
        d = (this.IntCapValue - 1);
        ulong da;
        da = (ulong)d;
        ulong a;
        a = oo;
        a = a & da;
        return a;
    }

    public virtual bool DataByteListSet(byte[] data, long index, long count, ulong value)
    {
        long d;
        d = this.IntCapValue - 1;
        ulong da;
        da = (ulong)d;
        ulong oo;
        oo = value;
        oo = oo & da;

        long i;
        i = 0;
        while (i < count)
        {
            int shiftCount;
            shiftCount = (int)(i * 8);

            ulong o;
            o = oo >> shiftCount;

            byte ob;
            ob = (byte)o;

            data[index + i] = ob;

            i = i + 1;
        }
        return true;
    }
    
    public virtual uint DataMidGet(byte[] data, long index)
    {
        return (uint)this.DataByteListGet(data, index, sizeof(uint));
    }

    public virtual bool DataMidSet(byte[] data, long index, uint value)
    {
        return this.DataByteListSet(data, index, sizeof(uint), value);
    }

    public virtual uint DataCharGet(byte[] data, long index)
    {
        return this.DataMidGet(data, index);
    }

    public virtual bool DataCharSet(byte[] data, long index, uint value)
    {
        return this.DataMidSet(data, index, value);
    }
}