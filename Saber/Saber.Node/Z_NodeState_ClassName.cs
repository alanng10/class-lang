namespace Saber.Node;

public class ClassNameNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteClassName(range);
        return true;
    }
}