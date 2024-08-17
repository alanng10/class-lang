class Stream : StreamStream
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Intern : new InternStream;
        this.Intern.Init();
        return true;
    }

    maide prusate Bool Final()
    {
        this.Intern.Final();
        return true;
    }

    field prusate Int Ident
    { 
        get
        {
            return this.Intern.Ident;
        } 
        set
        {
            this.Intern.Ident : value;
        }
    }

    field private InternStream Intern { get { return data; } set { data : value; } }

    field prusate Bool HasCount
    {
        get
        {
            return this.Intern.HasCount;
        }
        set
        {
            this.Intern.HasCount : value;
        }
    }

    field prusate Bool HasPos
    {
        get
        {
            return this.Intern.HasPos;
        }
        set
        {
            this.Intern.HasPos : value;
        }
    }

    field prusate Bool CanRead
    {
        get
        {
            return this.Intern.CanRead;
        }
        set
        {
            this.Intern.CanRead : value;
        }
    }

    field prusate Bool CanWrite
    {
        get
        {
            return this.Intern.CanWrite;
        }
        set
        {
            this.Intern.CanWrite : value;
        }
    }
    
    field prusate Int Count
    {
        get
        {
            return this.Intern.Count;
        }
        set
        {
            this.Intern.Count : value;
        }
    }

    field prusate Int Pos
    {
        get
        {
            return this.Intern.Pos;
        }
        set
        {
            this.Intern.Pos : value;
        }
    }

    maide prusate Bool PosSet(var Int value)
    {
        return this.Intern.PosSet(value);
    }

    field prusate Int Status
    {
        get
        {
            return this.Intern.Status;
        }
        set
        {
            this.Intern.Status : value;
        }
    }

    maide prusate Bool Read(var Data data, var Range range)
    {
        return this.Intern.Read(data.Value, data.Count, range.Index, range.Count);
    }

    maide prusate Bool Write(var Data data, var Range range)
    {
        return this.Intern.Write(data.Value, data.Count, range.Index, range.Count);
    }
}