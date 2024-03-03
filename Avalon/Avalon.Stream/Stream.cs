namespace Avalon.Stream;

public class Stream : Any
{
    public virtual bool Final()
    {
        return true;
    }

    public virtual ulong Ident
    {
        get
        {
            return 0;
        }
        set
        {
        }
    }

    public virtual bool HasCount
    {
        get
        {
            return true;
        }
        set
        {
        }
    }

    public virtual bool HasPos
    {
        get
        {
            return true;
        }
        set
        {
        }
    }

    public virtual bool CanRead
    {
        get
        {
            return true;
        }
        set
        {
        }
    }

    public virtual bool CanWrite
    {
        get
        {
            return true;
        }
        set
        {
        }
    }

    public virtual long Count
    {
        get
        {
            return 0;
        }
        set
        {
        }
    }

    public virtual long Pos
    {
        get
        {
            return 0;
        }
        set
        {
        }
    }

    public virtual bool PosSet(long value)
    {
        return true;
    }

    public virtual int Status
    {
        get
        {
            return 0;
        }
        set
        {
        }
    }

    public virtual bool Read(Data data, Range range)
    {
        return true;
    }

    public virtual bool Write(Data data, Range range)
    {
        return true;
    }
}