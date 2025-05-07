namespace Saber.Node;

public class CreateSetState : InfraState
{
    public override bool Init()
    {
        base.Init();

        CreateSetStateArg k;
        k = new CreateSetStateArg();
        k.Init();
        this.Arg = k;
        return true;
    }
}