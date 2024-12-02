class PolateStop : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;
        this.DrawInfra : share Infra;

        var Extern extern;
        extern : this.Extern;

        this.Intern : extern.PolateStop_New();
        extern.PolateStop_CountSet(this.Intern, this.Count);
        extern.PolateStop_Init(this.Intern);
        return true;        
    }

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.PolateStop_Final(this.Intern);
        extern.PolateStop_Delete(this.Intern);
        return true;
    }
}