namespace Avalon.Infra;

public class Stream : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = Infra.This;
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
            long a;
            a = this.Intern.Length;
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
            long a;
            a = this.Intern.Position;
            return a;
        }
        set
        {
        }
    }

    protected virtual Infra InfraInfra { get; set; }
    private SystemStream Intern { get; set; }

    public virtual bool PosSet(long value)
    {
        try
        {
            this.Intern.Seek(value, SystemSeekOrigin.Begin);
        }
        catch
        {
            return false;
        }
        return true;
    }

    public virtual bool Read(Data data, Range range)
    {
        if (!this.InfraInfra.ValidRange(data.Count, range.Index, range.Count))
        {
            return false;
        }

        if (!this.CanRead)
        {
            return false;
        }

        long count;
        count = range.Count;

        if (!this.InfraInfra.ValidRange(this.Count, this.Pos, count))
        {
            return false;
        }

        long i;
        i = 0;
        while (i < count)
        {
            int k;
            try
            {
                k = this.Intern.ReadByte();
            }
            catch
            {
                return false;
            }

            if (k == -1)
            {
                return false;
            }

            byte kd;
            kd = (byte)k;

            long ka;
            ka = kd;

            data.Set(range.Index + i, ka);

            i = i + 1;
        }
        
        return true;
    }

    public virtual bool Write(Data data, Range range)
    {
        if (!this.InfraInfra.ValidRange(data.Count, range.Index, range.Count))
        {
            return false;
        }

        if (!this.CanWrite)
        {
            return false;
        }

        long count;
        count = range.Count;

        long i;
        i = 0;
        while (i < count)
        {
            long ka;
            ka = data.Get(range.Index + i);

            byte kd;
            kd = (byte)ka;

            try
            {
                this.Intern.WriteByte(kd);
            }
            catch
            {
                return false;
            }

            i = i + 1;
        }

        return true;
    }
}