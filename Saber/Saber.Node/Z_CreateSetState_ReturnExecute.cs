namespace Saber.Node;

public class ReturnExecuteCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.SetArg;

        ReturnExecute node;
        node = arg.Node as ReturnExecute;
        node.Result = k.Field00 as Operate;
        return true;
    }
}