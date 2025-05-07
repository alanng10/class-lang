namespace Saber.Node;

public class StateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        State node;
        node = arg.Node as State;
        node.Value = k.Field00 as Array;
        return true;
    }
}