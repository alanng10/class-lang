namespace Saber.Node;

public class PartItemNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;

        Node a;
        a = this.Create.ExecuteComp(range);
        this.Result = a;
        return true;
    }
}