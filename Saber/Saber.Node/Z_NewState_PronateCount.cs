namespace Saber.Node;

public class PronateCountNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new PronateCount();
        return true;
    }
}