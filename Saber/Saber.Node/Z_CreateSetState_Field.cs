namespace Saber.Node;

public class FieldCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        Field node;
        node = (Field)arg.Node;
        node.Class = (ClassName)k.Field00;
        node.Name = (FieldName)k.Field01;
        node.Count = (Count)k.Field02;
        node.Get = (State)k.Field03;
        node.Set = (State)k.Field04;
        return true;
    }
}