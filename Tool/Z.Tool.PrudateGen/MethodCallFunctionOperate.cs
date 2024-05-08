namespace Z.Tool.PrudateGen;




class MethodCallFunctionOperate : FunctionOperate
{
    public virtual Method Method { get; set; }




    public override bool ExecuteName(StringBuilder sb)
    {
        if (!(this.Class == null))
        {
            sb.Append(this.Class.Name).Append(this.Gen.Combine);
        }
        
        
        sb.Append(this.Method.Name);



        return true;
    }




    public override bool ExecuteParam(StringBuilder sb)
    {
        Array param;

        param = this.Method.Param;



        bool b;

        b = this.Method.Static;


        if (b)
        {
            bool ba;

            ba = (param.Count == 0);


            if (!ba)
            {
                string oa;

                oa = this.Gen.GetParamItem(param, 0);


                this.Gen.AppendVarDeclare(sb, oa);


                this.Gen.AppendParamWithOffset(sb, param, 1);
            }
        }


        if (!b)
        {
            this.Gen.AppendVarDeclare(sb, "o");


            this.Gen.AppendParamWithOffset(sb, param, 0);
        }



        return true;
    }
}