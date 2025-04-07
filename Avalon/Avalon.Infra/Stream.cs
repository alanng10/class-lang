namespace Avalon.Infra;

public class Stream : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = global::Avalon.Infra.Intern.This;

        this.InternData = Extern.Data_New();
        Extern.Data_Init(this.InternData);

        this.InternRange = Extern.Range_New();
        Extern.Range_Init(this.InternRange);

        bool b;
        b = (this.SetIntern == 0);

        if (b)
        {
            this.Intern = Extern.Stream_New();
            Extern.Stream_Init(this.Intern);
        }
        if (!b)
        {
            this.Intern = (ulong)this.SetIntern;
        }

        this.Ident = (long)this.Intern;
        return true;
    }

    public virtual bool Final()
    {
        if (this.SetIntern == 0)
        {
            Extern.Stream_Final(this.Intern);
            Extern.Stream_Delete(this.Intern);
        }

        Extern.Range_Final(this.InternRange);
        Extern.Range_Delete(this.InternRange);

        Extern.Data_Final(this.InternData);
        Extern.Data_Delete(this.InternData);
        return true;
    }

    public virtual long SetIntern { get; set; }
    public virtual long Ident { get; set; }

    public virtual bool HasCount
    {
        get
        {
            ulong u;
            u = Extern.Stream_HasCount(this.Intern);
            bool a;
            a = (!(u == 0));
            return a;
        }
        set
        {
        }
    }

    public virtual bool HasPos
    {
        get
        {
            ulong u;
            u = Extern.Stream_HasPos(this.Intern);
            bool a;
            a = (!(u == 0));
            return a;
        }
        set
        {
        }
    }

    public virtual bool CanRead
    {
        get
        {
            ulong u;
            u = Extern.Stream_CanRead(this.Intern);
            bool a;
            a = (!(u == 0));
            return a;
        }
        set
        {
        }
    }

    public virtual bool CanWrite
    {
        get
        {
            ulong u;
            u = Extern.Stream_CanWrite(this.Intern);
            bool a;
            a = (!(u == 0));
            return a;
        }
        set
        {
        }
    }

    public virtual long Count
    {
        get
        {
            ulong u;
            u = Extern.Stream_CountGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
        }
    }

    public virtual long Pos
    {
        get
        {
            ulong u;
            u = Extern.Stream_PosGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
        }
    }

    public virtual long Status
    {
        get
        {
            ulong u;
            u = Extern.Stream_StatusGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
        }
    }

    private Intern InternIntern { get; set; }
    private ulong Intern { get; set; }
    private ulong InternRange { get; set; }
    private ulong InternData { get; set; }

    public virtual bool PosSet(long value)
    {
        ulong u;
        u = (ulong)value;
        Extern.Stream_PosSet(this.Intern, u);
        return true;
    }

    public virtual bool Read(Data data, Range range)
    {
        if (!this.CanRead)
        {
            return true;
        }

        this.InternDataCountSet(data.Count);
        this.InternRangeSet(range.Index, range.Count);

        this.InternIntern.StreamRead(this.Intern, data.Value, this.InternData, this.InternRange);
        return true;
    }

    public virtual bool Write(Data data, Range range)
    {
        if (!this.CanWrite)
        {
            return true;
        }

        this.InternDataCountSet(data.Count);
        this.InternRangeSet(range.Index, range.Count);

        this.InternIntern.StreamWrite(this.Intern, data.Value, this.InternData, this.InternRange);
        return true;
    }

    private bool InternDataCountSet(long count)
    {
        ulong countU;
        countU = (ulong)count;

        Extern.Data_CountSet(this.InternData, countU);
        return true;
    }

    private bool InternRangeSet(long index, long count)
    {
        ulong indexU;
        ulong countU;
        indexU = (ulong)index;
        countU = (ulong)count;

        Extern.Range_IndexSet(this.InternRange, indexU);
        Extern.Range_CountSet(this.InternRange, countU);
        return true;
    }
}