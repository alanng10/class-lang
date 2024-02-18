namespace Class.Node;





public class MieldNameNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteMieldName(this.Arg);



        return true;
    }
}