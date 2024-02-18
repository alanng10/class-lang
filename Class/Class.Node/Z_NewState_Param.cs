namespace Class.Node;





public class ParamNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new Param();



        return true;
    }
}