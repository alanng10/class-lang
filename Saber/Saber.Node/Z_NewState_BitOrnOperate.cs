namespace Class.Node;

public class BitOrnOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new BitOrnOperate();
        return true;
    }
}