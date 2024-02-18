namespace Class.Node;





public class VarNameNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new VarName();



        return true;
    }
}