namespace Class.Node;

public class VarNameNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteVarName(this.Arg);
        return true;
    }
}