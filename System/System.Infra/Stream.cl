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
        
        
    }
}