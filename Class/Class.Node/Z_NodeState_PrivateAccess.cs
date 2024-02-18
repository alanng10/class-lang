namespace Class.Node;





public class PrivateAccessNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecutePrivateAccess(this.Arg);



        return true;
    }
}