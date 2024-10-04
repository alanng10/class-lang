namespace Class.Node;

public class BitAndOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new BitAndOperate();
        return true;
    }
}