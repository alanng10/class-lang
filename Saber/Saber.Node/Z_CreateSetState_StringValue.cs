namespace Saber.Node;

public class StringValueCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        StringValue node;
        node = arg.Node as StringValue;
        node.Value = k.Field00 as String;
        return true;
    }
}