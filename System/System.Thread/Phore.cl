class Phore : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;
        var Extern extern;
        extern : this.Extern;
        this.Intern : extern.Phore_New();
        extern.Phore_InitCountSet(this.Intern, this.InitCount);
        extern.Phore_Init(this.Intern);
        return true;
    }
    
    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;
        extern.Phore_Final(this.Intern);
        extern.Phore_Delete(this.Intern);
        return true;
    }
    
    field prusate Int InitCount { get { return data; } set { data : value; } }
    field prusate Int Count
    {
        get
        {
            var Int a;
            a : this.Extern.Phore_CountGet(this.Intern);
            return a;
        }
        set
        {
        }
    }
    field private Extern Extern { get { return data; } set { data : value; } }
    field private Int Intern { get { return data; } set { data : value; } }
    
    maide prusate Bool Open()
    {
        return true;
    }
}