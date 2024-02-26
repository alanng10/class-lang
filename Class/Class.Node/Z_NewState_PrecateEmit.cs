namespace Class.Node;

public class PrecateEmitNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new PrecateEmit();
        return true;
    }
}