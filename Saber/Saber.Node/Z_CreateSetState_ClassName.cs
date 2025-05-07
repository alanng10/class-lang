namespace Saber.Node;

public class ClassNameCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        ClassName node;
        node = arg.Node as ClassName;
        node.Value = k.Field00 as String;
        return true;
    }
}