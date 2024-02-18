namespace Class.Node;





public class CompNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteComp(this.Arg);



        return true;
    }
}