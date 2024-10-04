namespace Saber.Node;

public class PartCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        Part node;
        node = (Part)arg.Node;
        node.Value = (Array)k.Field00;
        return true;
    }
}