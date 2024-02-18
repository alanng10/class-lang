namespace Class.Node;





public class StateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteState(this.Arg);



        return true;
    }
}