namespace Saber.Node;

public class ClassCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        Class node;
        node = arg.Node as Class;
        node.Name = k.Field00 as ClassName;
        node.Base = k.Field01 as ClassName;
        node.Part = k.Field02 as Part;
        return true;
    }
}