namespace Class.Node;





public class AccessNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteAccess(this.Arg);



        return true;
    }
}