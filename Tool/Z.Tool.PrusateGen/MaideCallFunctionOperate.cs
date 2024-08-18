namespace Z.Tool.PrusateGen;




class MaideCallFunctionOperate : FunctionOperate
{
    public virtual Maide Method { get; set; }




    public override bool ExecuteName()
    {
        if (!(this.Class == null))
        {
            this.Add(this.Class.Name).Add(this.Gen.Combine);
        }
                
        this.Add(this.Method.Name);

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