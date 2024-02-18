namespace Class.Node;





public class OperateExecuteNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteOperateExecute(this.Arg);



        return true;
    }
}