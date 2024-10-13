namespace Z.Tool.PrusateGen;

class InternStateGen : ExternGen
{
    protected virtual String TextInternState { get; set; }

    public override bool Execute()
    {
        this.TextInternState = this.ToolInfra.StorageTextRead(this.S("ToolData/Prusate/InternExtern.txt"));
        return base.Execute();
    }

    protected override bool AddClass(Class varClass)
    {
        if (varClass.HasNew)
        {
            this.AddClassNew(varClass);
        }

        this.AddFieldArray(varClass, varClass.Field);

        this.AddNewLineIfNotEmpty(varClass.Field);

        this.AddMaideArray(varClass, varClass.Maide);

        this.AddNewLineIfNotEmpty(varClass.Maide);

        this.AddFieldArray(varClass, varClass.StaticField);

        this.AddNewLineIfNotEmpty(varClass.StaticField);

        this.AddMaideArray(varClass, varClass.StaticMaide);

        this.AddNewLineIfNotEmpty(varClass.StaticMaide);
        return true;
    }

    protected override bool AddFunction(FunctionOperate functionOperate)
    {
        StringAdd kk;
        kk = new StringAdd();
        kk.Init();

        StringAdd ke;
        ke = this.ToolInfra.StringAdd;

        this.ToolInfra.StringAdd = kk;

        this.AddClear();
        
        functionOperate.ExecuteName();
        
        String name;
        name = this.AddResult();


        long paramCount;
        paramCount = functionOperate.ParamCount();

        bool ba;
        ba = functionOperate.Static();
        
        if (!ba)
        {
            paramCount = paramCount + 1;
        }

        String paramCountString;
        paramCountString = this.StringInt(paramCount);

        this.AddFunctionHeader();

        this.Add(this.IntTypeName).AddS(" ");

        functionOperate.ExecuteName();

        this.AddS("(");

        functionOperate.ExecuteParam();

        this.AddS(")").AddS(";").Add(this.NewLine);


        this.ToolInfra.StringAdd = ke;
        return true;
    }
}