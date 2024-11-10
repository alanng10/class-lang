class Comp : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;
        this.InternInfra : share InternInfra;
        this.ListInfra : share ListInfra;
        
        this.ModuleFoldPath : this.InternInfra.ModuleFoldPath;
        
        var Extern extern;
        extern : this.Extern;
        
        this.Intern : extern.StorageComp_New();
        extern.StorageComp_Init(this.Intern);
        return true;
    }

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.StorageComp_Final(this.Intern);
        extern.StorageComp_Delete(this.Intern);
        return true;
    }
    
    field prusate String ModuleFoldPath { get { return data; } set { data : value; } }
    field private Extern Extern { get { return data; } set { data : value; } }
    field private InternInfra InternInfra { get { return data; } set { data : value; } }
    field precate ListInfra ListInfra { get { return data; } set { data : value; } }
    field private Int Intern { get { return data; } set { data : value; } }
}