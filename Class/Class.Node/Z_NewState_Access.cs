namespace Class.Node;

public class AccessNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new Access();
        return true;
    }
}