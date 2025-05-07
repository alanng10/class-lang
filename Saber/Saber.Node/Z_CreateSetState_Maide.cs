namespace Saber.Node;

public class MaideCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        Maide node;
        node = arg.Node as Maide;
        node.Class = k.Field00 as ClassName;
        node.Name = k.Field01 as MaideName;
        node.Count = k.Field02 as Count;
        node.Param = k.Field03 as Param;
        node.Call = k.Field04 as State;
        return true;
    }
}