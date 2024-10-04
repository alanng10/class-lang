namespace Saber.Node;

public class CreateSetState : InfraState
{
    public override bool Init()
    {
        base.Init();
        CreateSetStateArg aa;
        aa = new CreateSetStateArg();
        aa.Init();
        this.Arg = aa;
        return true;
    }
}