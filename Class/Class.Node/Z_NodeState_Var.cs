namespace Class.Node;





public class VarNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteVar(this.Arg);



        return true;
    }
}