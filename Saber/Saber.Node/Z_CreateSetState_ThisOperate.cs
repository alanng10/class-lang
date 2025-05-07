namespace Saber.Node;

public class ThisOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        ThisOperate node;
        node = arg.Node as ThisOperate;
        return true;
    }
}