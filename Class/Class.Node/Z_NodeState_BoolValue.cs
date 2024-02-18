namespace Class.Node;





public class BoolValueNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteBoolValue(this.Arg);



        return true;
    }
}