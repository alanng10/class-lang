namespace Avalon.Infra;

public class Stream : Any
{
    public override bool Init()
    {
        base.Init();
        this.Intern = this.Ident as SystemStream;
        return true;
    }

    public virtual bool Final()
    {
        this.Intern.Dispose();
        return true;
    }

    public virtual object Ident { get; set; }

    public virtual bool HasCount { get; set; }
    public virtual bool HasPos { get; set; }

    public virtual bool CanRead
    {
        get
        {
            return this.Intern.CanRead;
        }
        set
        {
        }
    }

    public virtual bool CanWrite
    {
        get
        {
            return this.Intern.CanWrite;
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

    private SystemStream Intern { get; set; }

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