class MemoryStream : Stream
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

    field private InternStream Intern { get { return data; } set { data : value; } }
}