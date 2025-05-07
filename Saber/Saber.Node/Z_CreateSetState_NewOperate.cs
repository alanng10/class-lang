namespace Saber.Node;

public class NewOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        NewOperate node;
        node = arg.Node as NewOperate;
        node.Class = k.Field00 as ClassName;
        return true;
    }
}