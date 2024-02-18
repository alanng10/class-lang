namespace Class.Node;





public class FieldNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new Field();



        return true;
    }
}