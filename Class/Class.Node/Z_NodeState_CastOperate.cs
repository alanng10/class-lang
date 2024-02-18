namespace Class.Node;





public class CastOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteCastOperate(this.Arg);



        return true;
    }
}