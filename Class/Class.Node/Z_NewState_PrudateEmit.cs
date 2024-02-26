namespace Class.Node;

public class PrudateEmitNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new PrudateEmit();
        return true;
    }
}