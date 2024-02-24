namespace Class.Node;

public class EqualOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new EqualOperate();
        return true;
    }
}