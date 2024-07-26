namespace Class.Node;

public class ParamItemNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;

        Node a;
        a = this.Create.ExecuteVar(range);
        this.Result = a;
        return true;
    }
}