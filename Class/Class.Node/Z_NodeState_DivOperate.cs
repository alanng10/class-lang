namespace Class.Node;





public class DivOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteDivOperate(this.Arg);



        return true;
    }
}