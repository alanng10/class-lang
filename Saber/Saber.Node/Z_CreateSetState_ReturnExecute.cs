namespace Saber.Node;

public class ReturnExecuteCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        ReturnExecute node;
        node = (ReturnExecute)arg.Node;
        node.Result = (Operate)k.Field00;
        return true;
    }
}