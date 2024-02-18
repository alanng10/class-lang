namespace Class.Node;






public class ParamItemNodeState : NodeState
{
    public override bool Execute()
    {
        Node a;



        a = this.Create.ExecuteVar(this.Arg);




        this.Result = a;



        return true;
    }
}