namespace Class.Node;

public class MaideCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        Maide node;
        node = (Maide)arg.Node;
        node.Class = (ClassName)k.Field00;
        node.Name = (MaideName)k.Field01;
        node.Count = (Count)k.Field02;
        node.Param = (Param)k.Field03;
        node.Call = (State)k.Field04;
        return true;
    }
}