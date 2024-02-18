namespace Class.Node;





public class SetTargetNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new SetTarget();



        return true;
    }
}