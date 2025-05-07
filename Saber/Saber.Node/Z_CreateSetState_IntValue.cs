namespace Saber.Node;

public class IntValueCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        IntValue node;
        node = arg.Node as IntValue;
        node.Value = k.FieldInt;
        return true;
    }
}