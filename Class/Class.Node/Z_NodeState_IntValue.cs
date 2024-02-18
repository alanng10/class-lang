namespace Class.Node;





public class IntValueNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteIntValue(this.Arg);



        return true;
    }
}