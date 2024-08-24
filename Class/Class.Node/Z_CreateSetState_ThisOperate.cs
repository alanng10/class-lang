namespace Class.Node;

public class ThisOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        ThisOperate node;
        node = (ThisOperate)arg.Node;
        return true;
    }
}