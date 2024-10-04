namespace Saber.Node;

public class ClassNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new Class();
        return true;
    }
}