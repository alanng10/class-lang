namespace Class.Node;





public class OrnOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteOrnOperate(this.Arg);



        return true;
    }
}