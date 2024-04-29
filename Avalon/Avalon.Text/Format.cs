namespace Avalon.Text;

public class Format : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = Infra.This;
        return true;
    }

    protected virtual InfraInfra InfraInfra { get { return __D_InfraInfra; } set { __D_InfraInfra = value; } }
    protected InfraInfra __D_InfraInfra;
    protected virtual Infra TextInfra { get { return __D_TextInfra; } set { __D_TextInfra = value; } }
    protected Infra __D_TextInfra;

    public virtual int ExecuteCount(Text varBase, Array argList)
    {
        return 0;
    }

    public virtual bool ExecuteResult(Text varBase, Array argList, Text result)
    {
        return true;
    }

    public virtual bool ExecuteArgCount(FormatArg arg)
    {
        return true;
    }

    public virtual bool ExecuteArgResult(FormatArg arg, Text result)
    {
        return true;
    }
}