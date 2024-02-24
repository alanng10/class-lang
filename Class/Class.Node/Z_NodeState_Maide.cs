namespace Class.Node;

public class MaideNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteMaide(this.Arg);
        return true;
    }
}