namespace Class.Node;






public class StateItemNodeState : NodeState
{
    public override bool Execute()
    {
        Node a;



        a = this.Create.ExecuteExecute(this.Arg);




        this.Result = a;



        return true;
    }
}