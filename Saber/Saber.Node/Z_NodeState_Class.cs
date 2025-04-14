namespace Saber.Node;

public class ClassNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteClass(range);
        return true;
    }
}