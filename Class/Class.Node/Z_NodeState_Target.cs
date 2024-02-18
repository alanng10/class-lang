namespace Class.Node;





public class TargetNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteTarget(this.Arg);



        return true;
    }
}