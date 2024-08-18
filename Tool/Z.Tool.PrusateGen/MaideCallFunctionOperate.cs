namespace Z.Tool.PrusateGen;

class MaideCallFunctionOperate : FunctionOperate
{
    public virtual Maide Maide { get; set; }

    public override bool ExecuteName()
    {
        if (!(this.Class == null))
        {
            this.Add(this.Class.Name).Add(this.Gen.Combine);
        }
                
        this.Add(this.Maide.Name);
        return true;
    }

    public override bool ExecuteParam()
    {
        Array param;
        param = this.Maide.Param;

        bool b;
        b = this.Maide.Static;

        if (b)
        {
            bool ba;
            ba = (param.Count == 0);

            if (!ba)
            {
                String oa;
                oa = this.Gen.GetParamItem(param, 0);

                this.Gen.AddVarDeclare(oa);

                this.Gen.AddParamWithOffset(param, 1);
            }
        }

        if (!b)
        {
            this.Gen.AddVarDeclare(this.S("o"));

            this.Gen.AddParamWithOffset(param, 0);
        }
        return true;
    }
}