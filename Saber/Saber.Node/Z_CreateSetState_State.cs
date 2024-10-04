namespace Saber.Node;

public class StateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        State node;
        node = (State)arg.Node;
        node.Value = (Array)k.Field00;
        return true;
    }
}