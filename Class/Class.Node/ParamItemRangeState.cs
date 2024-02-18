namespace Class.Node;






public class ParamItemRangeState : RangeState
{
    public override bool Execute()
    {
        Range a;



        a = this.Create.ExecuteParamItemRange(this.Arg.Result, this.Arg.Range);




        this.Result = a;



        return true;
    }
}