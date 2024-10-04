namespace Saber.Node;

public class OperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        Operate node;
        node = (Operate)arg.Node;
        return true;
    }
}