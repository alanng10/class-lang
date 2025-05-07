namespace Saber.Node;

public class ArgueItemRangeState : RangeState
{
    public override bool Execute()
    {
        RangeStateArg arg;
        arg = this.Arg as RangeStateArg;

        this.Result = this.Create.ExecuteArgueItemRange(arg.Result, arg.Range);
        return true;
    }
}