namespace Class.Node;

public class ArgueItemNodeState : NodeState
{
    public override bool Execute()
    {
        Node a;
        a = this.Create.ExecuteOperate(this.Arg);
        this.Result = a;
        return true;
    }
}