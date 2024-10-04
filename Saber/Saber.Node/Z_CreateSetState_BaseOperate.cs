namespace Saber.Node;

public class BaseOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        BaseOperate node;
        node = (BaseOperate)arg.Node;
        return true;
    }
}