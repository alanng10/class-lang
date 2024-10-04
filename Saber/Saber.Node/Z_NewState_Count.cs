namespace Saber.Node;

public class CountNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new Count();
        return true;
    }
}