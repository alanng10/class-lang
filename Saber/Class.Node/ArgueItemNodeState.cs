namespace Class.Node;

public class ArgueItemNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;

        Node a;
        a = this.Create.ExecuteOperate(range);
        this.Result = a;
        return true;
    }
}