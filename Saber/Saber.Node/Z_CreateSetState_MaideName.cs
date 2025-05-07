namespace Saber.Node;

public class MaideNameCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        MaideName node;
        node = arg.Node as MaideName;
        node.Value = k.Field00 as String;
        return true;
    }
}