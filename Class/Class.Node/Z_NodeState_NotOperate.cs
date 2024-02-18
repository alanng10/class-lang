namespace Class.Node;





public class NotOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteNotOperate(this.Arg);



        return true;
    }
}