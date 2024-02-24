namespace Class.Node;

public class BitAndOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteBitAndOperate(this.Arg);
        return true;
    }
}