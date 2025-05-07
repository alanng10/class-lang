namespace Saber.Node;

public class NullOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        NullOperate node;
        node = arg.Node as NullOperate;
        return true;
    }
}