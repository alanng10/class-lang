namespace Class.Node;





public class IntSignHexValueNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new IntSignHexValue();



        return true;
    }
}