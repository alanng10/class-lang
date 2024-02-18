namespace Class.Node;





public class ThisOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteThisOperate(this.Arg);



        return true;
    }
}