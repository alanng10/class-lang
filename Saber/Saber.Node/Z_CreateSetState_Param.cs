namespace Saber.Node;

public class ParamCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        Param node;
        node = (Param)arg.Node;
        node.Value = (Array)k.Field00;
        return true;
    }
}