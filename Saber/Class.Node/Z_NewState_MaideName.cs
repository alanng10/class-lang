namespace Class.Node;

public class MaideNameNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new MaideName();
        return true;
    }
}