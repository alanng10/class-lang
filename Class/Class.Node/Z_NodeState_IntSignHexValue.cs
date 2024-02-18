namespace Class.Node;





public class IntSignHexValueNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteIntSignHexValue(this.Arg);



        return true;
    }
}