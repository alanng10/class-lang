namespace Avalon.Storage;

public class Stream : StreamStream
{
    public override bool Init()
    {
        base.Init();
        this.Intern = new InternStream();
        this.Intern.Init();
        return true;
    }

    public override bool Final()
    {
        this.Intern.Final();
        return true;
    }

    public override long Ident
    {
        get
        {
            return this.Intern.Ident;
        }
        set
        {
            this.Intern.Ident = value;
        }
    }

    public override bool HasCount
    {
        get
        {
            return this.Intern.HasCount;
        }
        set
        {
            this.Intern.HasCount = value;
        }
    }

    public override bool HasPos
    {
        get
        {
            return this.Intern.HasPos;
        }
        set
        {
            this.Intern.HasPos = value;
        }
    }

    public override bool CanRead
    {
        get
        {
            return this.Intern.CanRead;
        }
        set
        {
            this.Intern.CanRead = value;
        }
    }

    public override bool CanWrite
    {
        get
        {
            return this.Intern.CanWrite;
        }
        set
        {
            this.Intern.CanWrite = value;
        }
    }

    public override long Count
    {
        get
        {
            return this.Intern.Count;
        }
        set
        {
            this.Intern.Count = value;
        }
    }

    public override long Pos
    {
        get
        {
            return this.Intern.Pos;
        }
        set
        {
            this.Intern.Pos = value;
        }
    }

    public override long Status
    {
        get
        {
            return this.Intern.Status;
        }
        set
        {
            this.Intern.Status = value;
        }
    }

    private InternStream Intern { get; set; }

    public override bool PosSet(long value)
    {
        return this.Intern.PosSet(value);
    }

    public override bool Read(Data data, Range range)
    {
        return this.Intern.Read(data, range);
    }

    public override bool Write(Data data, Range range)
    {
        return this.Intern.Write(data, range);
    }
}