namespace Avalon.Text;

public class Join : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        return true;
    }

    public virtual Array Text { get; set; }
    protected virtual ListInfra ListInfra { get; set; }

    public virtual bool ExecuteStage()
    {
        return true;
    }
}