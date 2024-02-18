namespace Class.Node;





public class OperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteOperate(this.Arg);



        return true;
    }
}