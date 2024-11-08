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
    
    
}