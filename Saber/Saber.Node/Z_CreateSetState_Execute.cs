namespace Saber.Node;

public class ExecuteCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        Execute node;
        node = arg.Node as Execute;
        return true;
    }
}