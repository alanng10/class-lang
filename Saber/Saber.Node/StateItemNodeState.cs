namespace Class.Node;

public class StateItemNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;

        Node a;
        a = this.Create.ExecuteExecute(range);
        this.Result = a;
        return true;
    }
}