namespace Class.Node;

public class BitOrnOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteBitOrnOperate(this.Arg);
        return true;
    }
}