namespace Saber.Node;

public class NullOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        NullOperate node;
        node = (NullOperate)arg.Node;
        return true;
    }
}