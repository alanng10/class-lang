namespace Class.Node;





public class BaseOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteBaseOperate(this.Arg);



        return true;
    }
}