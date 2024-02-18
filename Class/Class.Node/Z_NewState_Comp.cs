namespace Class.Node;





public class CompNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new Comp();



        return true;
    }
}