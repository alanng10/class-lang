namespace Class.Node;

public class ClassNameNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new ClassName();
        return true;
    }
}