namespace Z.Tool.PrusateGen;

class FieldGetFunctionOperate : FunctionOperate
{
    public virtual Field Field { get; set; }

    public override bool ExecuteName()
    {
        this.Add(this.Class.Name).Add(this.Gen.Combine).Add(this.Field.Name).AddS("Get");
        return true;
    }

    public override bool ExecuteParam()
    {
        if (!this.Field.Static)
        {
            this.Gen.AddVarDeclare(this.S("o"));
        }
        return true;
    }

    public override long ParamCount()
    {
        return 0;
    }
}