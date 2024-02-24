namespace Class.Node;

public class StateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new State();
        return true;
    }
}