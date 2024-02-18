namespace Class.Node;





public class ArgueNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteArgue(this.Arg);



        return true;
    }
}