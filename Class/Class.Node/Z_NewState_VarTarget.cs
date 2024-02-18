namespace Class.Node;





public class VarTargetNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new VarTarget();



        return true;
    }
}