namespace Class.Node;

public class BracketOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        BracketOperate node;
        node = (BracketOperate)arg.Node;
        node.Any = (Operate)k.Field00;
        return true;
    }
}