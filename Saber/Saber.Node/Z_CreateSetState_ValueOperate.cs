namespace Saber.Node;

public class ValueOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        ValueOperate node;
        node = (ValueOperate)arg.Node;
        node.Value = (Value)k.Field00;
        return true;
    }
}