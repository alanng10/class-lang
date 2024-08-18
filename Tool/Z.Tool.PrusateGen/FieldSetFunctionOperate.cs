namespace Z.Tool.PrudateGen;




class FieldSetFunctionOperate : FunctionOperate
{
    public virtual Field Field { get; set; }




    public override bool ExecuteName(StringBuilder sb)
    {
        sb.Append(this.Class.Name).Append(this.Gen.Combine).Append(this.Field.Name).Append("Set");



        return true;
    }



    public override bool ExecuteParam(StringBuilder sb)
    {
        if (!this.Field.Static)
        {
            this.Gen.AppendVarDeclare(sb, "o");


            this.Gen.AppendParamCombine(sb);
        }



        this.Gen.AppendVarDeclare(sb, "value");



        return true;
    }
}