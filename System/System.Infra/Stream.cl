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
        b : (this.SetIntern = null);

        inf (b)
        {
            this.Intern : extern.Stream_New();
            extern.Stream_Init(this.Intern);
        }
        inf (~b)
        {
            this.Intern : cast Int(this.SetIntern);
        }
        this.Ident : this.Intern;
        return true;
    }
    
    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        inf (this.SetIntern = null)
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
    
    field prusate Any SetIntern { get { return data; } set { data : value; } }
    field prusate Any Ident { get { return data; } set { data : value; } }
    
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
    
    field prusate Int Count
    {
        get
        {
            var Int a;
            a : this.Extern.Stream_CountGet(this.Intern);
            return a;
        }
        set
        {
        }
    }
    
    field prusate Int Pos
    {
        get
        {
            var Int a;
            a : this.Extern.Stream_PosGet(this.Intern);
            return a;
        }
        set
        {
        }
    }
    
    field prusate Int Status
    {
        get
        {
            var Int a;
            a : this.Extern.Stream_StatusGet(this.Intern);
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
    
    maide prusate Bool PosSet(var Int value)
    {
        this.Extern.Stream_PosSet(this.Intern, value);
        return true;
    }
    
    maide prusate Bool Read(var Data data, var Range range)
    {
        inf (~this.CanRead)
        {
            return true;
        }

        this.InternDataCountSet(data.Count);
        this.InternRangeSet(range.Index, range.Count);

        this.InternInfra.StreamRead(this.Intern, data.Value, this.InternData, this.InternRange);
        return true;
    }
    
    maide prusate Bool Write(var Data data, var Range range)
    {
        inf (~this.CanWrite)
        {
            return true;
        }

        this.InternDataCountSet(data.Count);
        this.InternRangeSet(range.Index, range.Count);

        this.InternInfra.StreamWrite(this.Intern, data.Value, this.InternData, this.InternRange);
        return true;
    }
    
    maide private Bool InternDataCountSet(var Int count)
    {
        this.Extern.Data_CountSet(this.InternData, count);
        return true;
    }
    
    maide private Bool InternRangeSet(var Int index, var Int count)
    {
        this.Extern.Range_IndexSet(this.InternRange, index);
        this.Extern.Range_CountSet(this.InternRange, count);
        return true;
    }
}