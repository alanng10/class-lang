class Form : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;
        this.InfraInfra : share InfraInfra;

        var Extern extern;
        extern : this.Extern;

        this.Intern : extern.Form_New();
        extern.Form_Init(this.Intern);
        return true;
    }


}