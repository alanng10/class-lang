namespace Class.Node;





public class VarTargetNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteVarTarget(this.Arg);



        return true;
    }
}