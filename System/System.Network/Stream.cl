class Stream : StreamStream
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Intern : new InternStream;
        this.Intern.SetIntern : this.InitIdent;
        this.Intern.Init();
        return true;
    }

    maide prusate Bool Final()
    {
        this.Intern.Final();
        return true;
    }

    field prusate Int InitIdent { get { return data; } set { data : value; } }

    field prusate Any Ident
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

    field private InternStream Intern { get { return data; } set { data : value; } }
    
    maide prusate Bool PosSet(var Int value)
    {
        return this.Intern.PosSet(value);
    }
    
    maide prusate Bool Read(var Data data, var Range range)
    {
        return this.Intern.Read(data, range);
    }
    
    maide prusate Bool Write(var Data data, var Range range)
    {
        return this.Intern.Write(data, range);
    }
}