namespace Saber.Node;

public class ParamItemRangeState : RangeState
{
    public override bool Execute()
    {
        RangeStateArg arg;
        arg = this.Arg as RangeStateArg;

        this.Result = this.Create.ExecuteParamItemRange(arg.Result, arg.Range);
        return true;
    }
}