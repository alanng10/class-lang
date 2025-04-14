namespace Saber.Node;

public class ExecuteCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.SetArg;

        Execute node;
        node = arg.Node as Execute;
        return true;
    }
}