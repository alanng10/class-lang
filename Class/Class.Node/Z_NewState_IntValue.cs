namespace Class.Node;





public class IntValueNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new IntValue();



        return true;
    }
}