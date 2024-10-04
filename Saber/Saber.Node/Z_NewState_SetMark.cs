namespace Saber.Node;

public class SetMarkNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new SetMark();
        return true;
    }
}