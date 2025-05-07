namespace Saber.Node;

public class OperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        Operate node;
        node = arg.Node as Operate;
        return true;
    }
}