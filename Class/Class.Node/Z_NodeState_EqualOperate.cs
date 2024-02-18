namespace Class.Node;





public class EqualOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteEqualOperate(this.Arg);



        return true;
    }
}