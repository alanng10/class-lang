namespace Class.Node;

public class CreateOperateState : InfraState
{
    public override bool Init()
    {
        base.Init();
        CreateOperateStateArg aa;
        aa = new CreateOperateStateArg();
        aa.Init();
        this.Arg = aa;
        return true;
    }
}