namespace Saber.Node;

public class BaseOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        BaseOperate node;
        node = arg.Node as BaseOperate;
        return true;
    }
}