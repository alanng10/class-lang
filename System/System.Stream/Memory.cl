class Memory : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;

        var Extern extern;
        extern : this.Extern;
        this.Intern : extern.Memory_New();
        extern.Memory_Init(this.Intern);
        return true;
    }
    
    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.Memory_Final(this.Intern);
        extern.Memory_Delete(this.Intern);
        return true;        
    }

    field prusate Stream Stream { get { return data; } set { data : value; } }
    field private Extern Extern { get { return data; } set { data : value; } }
    field private Int Intern { get { return data; } set { data : value; } }
    
    maide prusate Bool Open()
    {
        inf (~(this.Stream = null))
        {
            return true;
        }
        
        var Stream stream;
        stream : this.CreateStream();
        
        var Int k;
        k : stream.Ident;
        
        var Extern extern;
        extern : this.Extern;
        
        extern.Memory_StreamSet(this.Intern, k);
        extern.Memory_Open(this.Intern);
        
        this.Stream : stream;
        return true;
    }
    
    maide prusate Bool Close()
    {
        var Extern extern;
        extern : this.Extern;

        extern.Memory_Close(this.Intern);
        extern.Memory_StreamSet(this.Intern, 0);

        this.Stream.Final();
        this.Stream : null;
        return true;
    }
    
    maide precate Stream CreateStream()
    {
        var MemoryStream k;
        k : new MemoryStream;
        k.Init();
        var Stream a;
        a : k;
        return a;
    }
}