namespace Class.Node;





public class IntHexValueNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteIntHexValue(this.Arg);



        return true;
    }
}