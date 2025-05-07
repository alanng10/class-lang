namespace Saber.Node;

public class AreExecuteCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        AreExecute node;
        node = arg.Node as AreExecute;
        node.Mark = k.Field00 as Mark;
        node.Value = k.Field01 as Operate;
        return true;
    }
}