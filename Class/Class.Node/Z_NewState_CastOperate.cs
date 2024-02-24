namespace Class.Node;

public class CastOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new CastOperate();
        return true;
    }
}