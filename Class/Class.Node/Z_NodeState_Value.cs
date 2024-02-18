namespace Class.Node;





public class ValueNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteValue(this.Arg);



        return true;
    }
}