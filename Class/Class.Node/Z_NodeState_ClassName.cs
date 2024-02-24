namespace Class.Node;

public class ClassNameNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteClassName(this.Arg);
        return true;
    }
}