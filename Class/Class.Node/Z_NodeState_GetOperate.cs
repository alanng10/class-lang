namespace Class.Node;





public class GetOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteGetOperate(this.Arg);



        return true;
    }
}