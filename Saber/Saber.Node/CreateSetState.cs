namespace Saber.Node;

public class CreateSetState : InfraState
{
    public override bool Init()
    {
        base.Init();
        this.Arg = new CreateSetStateArg();
        this.Arg.Init();
        return true;
    }
}