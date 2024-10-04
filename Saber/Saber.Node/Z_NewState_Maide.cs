namespace Saber.Node;

public class MaideNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new Maide();
        return true;
    }
}