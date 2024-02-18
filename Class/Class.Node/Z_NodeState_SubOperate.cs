namespace Class.Node;





public class SubOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteSubOperate(this.Arg);



        return true;
    }
}