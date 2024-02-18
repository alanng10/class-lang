namespace Class.Node;





public class MieldNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new Mield();



        return true;
    }
}