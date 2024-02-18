namespace Class.Node;






public class StateItemRangeState : RangeState
{
    public override bool Execute()
    {
        Range a;



        a = this.Create.ExecuteExecuteRange(this.Arg.Result, this.Arg.Range);




        this.Result = a;



        return true;
    }
}