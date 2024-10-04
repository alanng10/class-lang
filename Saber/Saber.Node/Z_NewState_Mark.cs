namespace Saber.Node;

public class MarkNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new Mark();
        return true;
    }
}