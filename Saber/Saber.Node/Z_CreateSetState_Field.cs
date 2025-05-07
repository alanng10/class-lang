namespace Saber.Node;

public class FieldCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        Field node;
        node = arg.Node as Field;
        node.Class = k.Field00 as ClassName;
        node.Name = k.Field01 as FieldName;
        node.Count = k.Field02 as Count;
        node.Get = k.Field03 as State;
        node.Set = k.Field04 as State;
        return true;
    }
}