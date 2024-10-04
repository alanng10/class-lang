namespace Saber.Node;

public class ClassNameCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        ClassName node;
        node = (ClassName)arg.Node;
        node.Value = (String)k.Field00;
        return true;
    }
}