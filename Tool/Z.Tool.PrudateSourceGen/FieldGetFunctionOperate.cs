namespace Z.Tool.PrudateSourceGen;




class FieldGetFunctionOperate : FunctionOperate
{
    public virtual Field Field { get; set; }




    public override bool ExecuteName(StringBuilder sb)
    {
        sb.Append(this.Class.Name).Append(this.Gen.Combine).Append(this.Field.Name).Append("Get");



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