namespace Class.Node;





public class BitSignRightOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteBitSignRightOperate(this.Arg);



        return true;
    }
}