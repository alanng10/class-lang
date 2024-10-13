namespace Z.Tool.PrusateGen;

class FieldSetFunctionOperate : FunctionOperate
{
    public virtual Field Field { get; set; }

    public override bool ExecuteName()
    {
        this.Add(this.Class.Name).Add(this.Gen.Combine).Add(this.Field.Name).AddS("Set");
        return true;
    }

    public override bool ExecuteParam()
    {
        if (!this.Field.Static)
        {
            this.Gen.AddVarDeclare(this.S("o"));

            this.Gen.AddParamCombine();
        }

        this.Gen.AddVarDeclare(this.S("value"));
        return true;
    }

    public override long ParamCount()
    {
        return 1;
    }
}