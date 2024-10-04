namespace Class.Node;

public class NewOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        NewOperate node;
        node = (NewOperate)arg.Node;
        node.Class = (ClassName)k.Field00;
        return true;
    }
}