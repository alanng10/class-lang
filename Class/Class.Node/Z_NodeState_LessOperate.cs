namespace Class.Node;





public class LessOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteLessOperate(this.Arg);



        return true;
    }
}