namespace Class.Node;





public class BitRightOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteBitRightOperate(this.Arg);



        return true;
    }
}