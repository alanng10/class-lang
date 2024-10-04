namespace Saber.Node;

public class ArgueCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        Argue node;
        node = (Argue)arg.Node;
        node.Value = (Array)k.Field00;
        return true;
    }
}