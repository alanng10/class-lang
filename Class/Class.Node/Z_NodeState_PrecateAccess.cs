namespace Class.Node;





public class PrecateAccessNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecutePrecateAccess(this.Arg);



        return true;
    }
}