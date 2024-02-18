namespace Class.Node;





public class NullOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteNullOperate(this.Arg);



        return true;
    }
}