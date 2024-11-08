namespace Saber.Console;

public class ClassInitGen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.ClassInfra = ClassInfra.This;
        return true;
    }

    public virtual ClassModule Module { get; set; }
    public virtual Array Result { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }

    public virtual bool Execute()
    {
        return true;
    }
}