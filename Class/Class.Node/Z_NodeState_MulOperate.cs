namespace Class.Node;





public class MulOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteMulOperate(this.Arg);



        return true;
    }
}