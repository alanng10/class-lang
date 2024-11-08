class Stream : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;
        this.InternInfra : share InternInfra;
        
        var Extern extern;
        extern : this.Extern;
        
        this.InternData : extern.Data_New();
        extern.Data_Init(this.InternData);
        
        this.InternRange :extern.Range_New();
        extern.Range_Init(this.InternRange);
        
        var Bool b;
        b : (this.SetIntern = 0);
        
        inf (b)
        {
            this.Intern : extern.Stream_New();
            extern.Stream_Init(this.Intern);
        }
        inf (~b)
        {
            this.Intern : this.SetIntern;
        }
        this.Ident : this.Intern;
        return true;
    }
    
    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;
        
        inf (this.SetIntern = 0)
        {
            extern.Stream_Final(this.Intern);
            extern.Stream_Delete(this.Intern);
        }
        
        extern.Range_Final(this.InternRange);
        extern.Range_Delete(this.InternRange);
        
        extern.Data_Final(this.InternData);
        extern.Data_Delete(this.InternData);
        return true;
    }
    
    field prusate Int SetIntern { get { return data; } set { data : value; } }
    field prusate Int Ident { get { return data; } set { data : value; } }
    
    field prusate Bool HasCount
    {
        get
        {
            var Int u;
            u : this.Extern.Stream_HasCount(this.Intern);
            var Bool a;
            a : ~(u = 0);
            return a;
        }
        set
        {
        }
    }
    
    field prusate Bool HasPos
    {
        get
        {
            var Int u;
            u : this.Extern.Stream_HasPos(this.Intern);
            var Bool a;
            a : ~(u = 0);
            return a;
        }
        set
        {
        }
    }
    
    field prusate Bool CanRead
    {
        get
        {
            var Int u;
            u : this.Extern.Stream_CanRead(this.Intern);
            var Bool a;
            a : ~(u = 0);
            return a;
        }
        set
        {
        }
    }
    
    field prusate Bool CanWrite
    {
        get
        {
            var Int u;
            u : this.Extern.Stream_CanWrite(this.Intern);
            var Bool a;
            a : ~(u = 0);
            return a;
        }
        set
        {
        }
    }
    
    field private Extern Extern { get { return data; } set { data : value; } }
    field private InternInfra InternInfra { get { return data; } set { data : value; } }
    field private Int Intern { get { return data; } set { data : value; } }
    field private Int InternRange { get { return data; } set { data : value; } }
    field private Int InternData { get { return data; } set { data : value; } }

}