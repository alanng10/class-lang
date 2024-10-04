namespace Class.Node;

public class VarMarkNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new VarMark();
        return true;
    }
}