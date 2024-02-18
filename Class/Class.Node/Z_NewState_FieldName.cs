namespace Class.Node;





public class FieldNameNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new FieldName();



        return true;
    }
}