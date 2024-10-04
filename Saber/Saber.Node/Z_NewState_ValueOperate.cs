namespace Class.Node;

public class ValueOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new ValueOperate();
        return true;
    }
}