namespace Class.Node;

public class EmitNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new Emit();
        return true;
    }
}