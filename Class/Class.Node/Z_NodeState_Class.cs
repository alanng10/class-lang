namespace Class.Node;





public class ClassNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteClass(this.Arg);



        return true;
    }
}