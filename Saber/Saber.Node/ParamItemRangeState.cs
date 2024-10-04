namespace Saber.Node;

public class ParamItemRangeState : RangeState
{
    public override bool Execute()
    {
        RangeStateArg arg;
        arg = (RangeStateArg)this.Arg;

        Range a;
        a = this.Create.ExecuteParamItemRange(arg.Result, arg.Range);
        this.Result = a;
        return true;
    }
}