namespace Class.Node;





public class VarNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new Var();



        return true;
    }
}