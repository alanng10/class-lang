namespace Class.Node;

public class MaideNameNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteMaideName(this.Arg);
        return true;
    }
}