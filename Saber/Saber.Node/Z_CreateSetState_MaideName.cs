namespace Saber.Node;

public class MaideNameCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        MaideName node;
        node = (MaideName)arg.Node;
        node.Value = (String)k.Field00;
        return true;
    }
}