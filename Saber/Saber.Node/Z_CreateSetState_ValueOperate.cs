namespace Saber.Node;

public class ValueOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        ValueOperate node;
        node = arg.Node as ValueOperate;
        node.Value = k.Field00 as Value;
        return true;
    }
}