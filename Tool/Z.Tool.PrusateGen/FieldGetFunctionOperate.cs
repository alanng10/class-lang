namespace Z.Tool.PrusateGen;

class FieldGetFunctionOperate : FunctionOperate
{
    public virtual Field Field { get; set; }

    public override bool ExecuteName()
    {
        this.Add(this.Class.Name).Add(this.Gen.Combine).Add(this.Field.Name).AddS("Get");
        return true;
    }

    public override bool ExecuteParam(StringBuilder sb)
    {
        if (!this.Field.Static)
        {
            this.Gen.AppendVarDeclare(sb, "o");
        }



        return true;
    }
}